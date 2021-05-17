// Carregar configurações do datatables
$(document).ready(function () {
    renderizarDesignDataTables('dtSessao', true);
});

// Função para validar view
function controle(id_acao) {
    let acao = null;
    if (id_acao == 0) {
        acao = 'ManterSessao';
    } else if (id_acao == 1) {
        acao = 'ExcluirSessao';
    }
    return acao;
}

// Carregar modal
function modal(id_acao, cod) {
    $.ajax({
        url: criarURL('Sessao', controle(id_acao)),
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
            $('#modalSessao').html('');
            $('#modalSessao').html(response);
            $('#modal-sessao').modal('show');
        },
        error: function (e) {
            console.log(e)
        }
    })
}

// Manter (incluir e altualizar) á sessão
function manterSessao(cod) {
    $('#frmSessao').validate({
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
            'IdFilme': {
                required: !0,
            },
            'IdSala': {
                required: !0,
            },
            'DataSessao': {
                required: !0,
                minlength: 10,
                maxlength: 10
            },
            'HoraInicioSessao': {
                required: !0,
            },
            'ValorIngresso': {
                required: !0,
            },
            'TipoAnimacao': {
                required: !0,
            },
            'TipoAudio': {
                required: !0,
            }
        },
        messages: {
            'IdFilme': {
                required: 'Selecione um filme!'
            },
            'IdSala': {
                required: 'Selecione uma sala!'
            },
            'DataSessao': {
                required: 'Preencha a data da sessão!',
                minlength: 'Por favor, indique 10.',
                maxlength: 'Por favor, indique 10.'
            },
            'HoraInicioSessao': {
                required: 'Preencha a hora de incio!'
            },
            'ValorIngresso': {
                required: 'Preencha o valor do ingresso!'
            },
            'TipoAnimacao': {
                required: 'Selecione o tipo de animação!'
            },
            'TipoAudio': {
                required: 'Selecione o tipo de áudio!'
            }
        },
        submitHandler: function (form) {

            var formData = new FormData();
            formData.append('IdSessao', cod);
            formData.append('IdFilme', $('#IdFilme').val());
            formData.append('IdSala', $('#IdSala').val());
            formData.append('DataSessao', $('#DataSessao').val());
            formData.append('HoraInicioSessao', $('#HoraInicioSessao').val());
            formData.append('ValorIngresso', $('#ValorIngresso').val());
            formData.append('TipoAnimacao', $('#TipoAnimacao').val());
            formData.append('TipoAudio', $('#TipoAudio').val());

            $.ajax({
                url: criarURL('Sessao', cod === null ? 'IncluirSessao' : 'EditarSessao'),
                type: cod === null ? 'POST' : 'PUT',
                dataType: 'JSON',
                data: formData,
                async: true,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.success) {
                        atualizarDesignDataTables('Sessao', 'GridSessao', 'idGridSessao', 'dtSessao', 0, 'modal-sessao', null);
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

// Excluir sessão
function excluirSessao(cod) {
    $.ajax({
        url: criarURL('Sessao', 'DeleteSessao'),
        type: 'DELETE',
        dataType: 'JSON',
        data: { cod: cod },
        async: true,
        cache: false,
        success: function (response) {
            if (response.success) {
                atualizarDesignDataTables('Sessao', 'GridSessao', 'idGridSessao', 'dtSessao', 0, 'modal-sessao', null);
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

// Funções carregar lista de filems
function carregarListarFilmes(cod) {
    $.ajax({
        url: criarURL('Filme', 'CarregarComboboxFilme'),
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        success: function (response) {
            if (response.success) {
                var option = '<option value="">Selecione</option>';
                $.each(response.result, function (index, element) {
                    option += '<option value="' + element.idFilme + '">' + element.titulo + '</option>';
                });
                $('#IdFilme').html(option).val(cod);
            }
        },
        error: function (e) {
            console.log(e);
        }
    });
}

// Funções carregar Tipo Audio
function carregarListarSala(cod) {
    $.ajax({
        url: criarURL('Sala', 'ListarSala'),
        type: 'GET',
        dataType: 'JSON',
        async: true,
        cache: false,
        success: function (response) {
            if (response.success) {
                var option = '<option value="">Selecione</option>';
                $.each(response.result, function (index, element) {
                    option += '<option value="' + element.idSala + '">' + element.nome + '</option>';
                });
                $('#IdSala').html(option).val(cod);
            }
        },
        error: function (e) {
            console.log(e);
        }
    });
}

// Funções carregar Tipo Audio
function carregarListarTipoAudio(cod) {
    let option  = '<option value="">Selecione</option>';
        option += '<option value="Original"> Original</option>';
        option += '<option value="Dublado">Dublado</option>';
    $('#TipoAudio').html(option).val(cod);
}

// Funções carregar Tipo Animação
function carregarListarTipoAnimacao(cod) {
    let option  = '<option value="">Selecione</option>';
        option += '<option value="3d">3d</option>';
        option += '<option value="2d">2d</option>';
    $('#TipoAnimacao').html(option).val(cod);
}