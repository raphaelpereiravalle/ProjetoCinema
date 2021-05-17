// // Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Função para criar url para a controller
function criarURL(controller, action) {
    return location.protocol + '//' + location.host + '/' + controller + '/' + action;
}

// Função de notificação 
function notificacao(tipo, titulo, mensagem) {
    // Fecha a notificação anterior
    $.notifyClose();

    var content = {};
    // content.title = titulo  + '<br>';
    // content.icon = 'glyphicon glyphicon-warning-sign';
    content.message = mensagem;

    $.notify(content, {
        type: tipo,
        spacing: 10,
        timer: 1000,
        offset: 60,
        placement: {
            from: 'top',
            align: 'center'
        },
        z_index: 10000
    });
}

// Função para validar variáveis
function isNullOrWhiteSpace(value) {
    return value === null || value === "" || value === undefined;
}

// Função para esconder modal, recarregar datatables, limpar mensagens
function fecharModal(tempo, modal) {
    if (!isNullOrWhiteSpace(tempo) && !isNullOrWhiteSpace(modal)) {
        window.setTimeout(function () {
            $('#' + modal).modal("hide"); //Fechar modal
        }, tempo);
    }
}

// Função para renderizar design do datatables 
// Parâmetro: id da table, scrollX quando a table for muito largo habilitar a rolagem horizontal
function renderizarDesignDataTables(id, info) {

    $.fn.DataTable.ext.classes.sWrapper = 'dataTables_wrapper dt-bootstrap4';
    $.fn.DataTable.ext.classes.sFilterInput = 'form-control form-control-sm';
    $.fn.DataTable.ext.classes.sLengthSelect = 'form-control form-control-sm';
    $.fn.DataTable.ext.errMode = 'throw';

    $('#' + id).DataTable({
        info: info,
        processing: true,
        serverSide: false,
        responsive: true,
        autoWidth: true,
        destroy: true,
        ordering: false,
        stateSave: false,
        displayLength: 10,
        pageLength: 10,
        lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, 'Todos']],
        dom: "<'row'<'col-sm-12'<'text-center bg-body-light py-2 mb-2'B>>><'row'<'col-sm-12 col-md-6'l><'col-sm-12 col-md-6'f>><'row'<'col-sm-12'tr>><'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
        renderer: 'bootstrap',
        sType: 'brazilian',
        buttons: [
        ],
        oLanguage: {
            sLengthMenu: '_MENU_',
            sInfo: 'Mostrando <strong>_START_</strong>-<strong>_END_</strong> de <strong>_TOTAL_</strong> registros',
            sInfoFiltered: '(Filtro de _MAX_ registros)',
            sSearch: 'Pesquisar: ',
            sZeroRecords: 'Nenhum registro encontrado',
            sProcessing: 'Processando',
            sLoadingRecords: 'Nenhum registro encontrado',
            sInfoEmpty: 'Mostrando <strong>_START_</strong>-<strong>_END_</strong> de <strong>_TOTAL_</strong> registros',
            oPaginate: {
                sFirst: '<i class="fa fa-angle-double-left"></i>',
                sPrevious: '<i class="fa fa-angle-left"></i>',
                sNext: '<i class="fa fa-angle-right"></i>',
                sLast: '<i class="fa fa-angle-double-right"></i>'
            }
        }
    });
}

// Função para atualizar datatables após ação
function atualizarDesignDataTables(controller, metodo, idGrid, datatables, tempo, modal, data) {
    $.ajax({
        url: criarURL(controller, metodo),
        type: 'GET',
        dataType: 'HTML',
        data: data === null ? {} : data,
        async: false,
        cache: false,
        success: function (response) {
            $('#' + idGrid).html('');
            $('#' + idGrid).html(response);
            fecharModal(tempo, modal);
            renderizarDesignDataTables(datatables, true);
        },
        error: function (e) {
            console.log(e);
        }
    });
}