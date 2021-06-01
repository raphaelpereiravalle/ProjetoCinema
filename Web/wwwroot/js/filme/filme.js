// Carregar configurações do datatables
$(document).ready(function () {
    renderizarDesignDataTables('dtFilme', true);
});

// Função para validar view
function controle(id_acao) {
    let acao = null;
    if (id_acao == 0) {
        acao = 'ManterFilme';
    } else if (id_acao == 1) {
        acao = 'ExcluirFilme';
    }
    return acao;
}

// Carregar modal
function modal(id_acao, cod) {
    $.ajax({
        url: criarURL('Filme', controle(id_acao)),
        type: 'GET',
        dataType: 'HTML',
        data: { cod: cod === null ? null : cod },
        success: function (response) {
            if (!($('.modal.in').length)) {
                $('.modal-dialog').css({
                    top: 85,
                    left: 0
                });
            }
            $('#modalFilme').html('');
            $('#modalFilme').html(response);
            $('#modal-filme').modal('show');
        },
        error: function (e) {
            console.log(e)
        }
    })
}

// Manter (incluir e altualizar) Filme
function manterFilme(cod) {
    $('#frmFilme').validate({
        errorClass: "invalid-feedback animated fadeInDown",
        errorElement: "div",
        errorPlacement: function (e, a) {
            jQuery(a).parents(".form-group > div").append(e)
        },
        highlight: function (e) { jQuery(e).closest(".form-group").removeClass("is-invalid").addClass("is-invalid") },
        success: function (e) {
            jQuery(e).closest(".form-group").removeClass("is-invalid"), jQuery(e).remove()
        },
        rules: {
            'Titulo': {
                required: !0,
                minlength: 3,
                maxlength: 100
            },
            'Duracao': {
                required: !0,
                minlength: 5,
                maxlength: 5
            },
            'Descricao': {
                required: !0,
                minlength: 5,
                maxlength: 800
            },
            'Imagem': {
                required: !0,
                extension: "jpg|jpeg|png|JPG|JPEG|PNG"
            }
        },
        messages: {
            'Titulo': {
                required: 'Preencha o nome do filme!',
                minlength: 'Por favor, indique no mínino 3 caracteres.',
                maxlength: 'Por favor, indique não mais do que 150 caracteres.'
            },
            'Duracao': {
                required: 'Preencha o duração!',
                minlength: 'Por favor, indique a duração.'
            },
            'Descricao': {
                required: 'Preencha o descrição!',
                minlength: 'Por favor, indique no mínino 5 caracteres.',
                maxlength: 'Por favor, indique não mais do que 800 caracteres.'
            },
            'Imagem': {
                required: "Selecione uma imagem!",
                extension: "Você só tem permissão para fazer upload de imagens jpg ou png"
            }
        },
        submitHandler: function (form) {

            var _arquivo = document.getElementById('Imagem').files[0];

            var formData = new FormData();
            formData.append('IdFilme', cod);
            formData.append('Titulo', $('#Titulo').val());
            formData.append('Duracao', $('#Duracao').val());
            formData.append('Descricao', $('#Descricao').val());
            formData.append('Arquivo', _arquivo);
            formData.append('Ativo', $("#Ativo").is(':checked'));
         
            $.ajax({
                url: criarURL('Filme', cod === null ? 'IncluirFilme' : 'EditarFilme'),
                type: cod === null ? 'POST' : 'PUT',
                dataType: 'JSON',
                data: formData,
                async: true,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.success) {
                        atualizarDesignDataTables('Filme', 'GridFilme', 'idGridFilme', 'dtFilme', 0, 'modal-filme', null);
                        notificacao('success', 'Sucesso', response.message);
                    } else {
                        notificacao('danger', 'Erro', response.message);
                    }
                },
                error: function (e) {
                    console.log(e);
                }
            });
        }
    });
}

// Excluir Filme
function excluirFilme(cod) {
    $.ajax({
        url: criarURL('Filme', 'DeleteFilme'),
        type: 'DELETE',
        dataType: 'JSON',
        data: { cod: cod },
        async: true,
        cache: false,
        success: function (response) {
            if (response.success) {
                atualizarDesignDataTables('Filme', 'GridFilme', 'idGridFilme', 'dtFilme', 0, 'modal-filme', null);
                notificacao('success', 'Sucesso', response.message);
            } else {
                notificacao('danger', 'Erro', response.message);
            }
        },
        error: function (e) {
            console.log(e);
        }
    });
}
