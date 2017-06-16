var adminDetails = function () {
    var getCandidateList = '';

    var initializePIFormLinkRequest = function () {
        $('#btnClear').click(function () {
            $('#txtName').val('');
            $('#txtEmailAddress').val('');
            $('#txtPILink').val('');
            $('#divMessage').html('');
        });
    };

    var initializeAdminSearch = function (srvGetCandidateList) {
        getCandidateList = srvGetCandidateList;

        $('#jqGrid').jqGrid({
            url: getCandidateList,
            datatype: "json",
            colModel: [
	                { name: 'Id', key: true, width: 25, resizable: false, sortable: false, hidden: true },
	                { name: 'Name', key: true, width: 220, resizable: false, sortable: false, hidden: false },
	                { name: 'EmailAddress', key: true, width: 220, resizable: false, sortable: false, hidden: false },
                    { name: 'CreatedOn', key: true, width: 150, resizable: false, sortable: false, hidden: false },
	                { name: 'Status', key: true, width: 80, resizable: false, sortable: false, hidden: false },
                    { name: 'Action', key: true, width: 80, resizable: false, sortable: false, hidden: false }
            ],
            contentType: "application/json; charset-utf-8",
            mtype: 'GET',
            viewrecords: true,
            sortname: 'CreatedOn',
            sortorder: 'DESC',
            width: 'auto',
            height: 'auto',
            shrinkToFit: false,
            pager: '#jqGridPager',
            postData: {
                Name: $('#txtName').val(),
                EmailAddress: $('#txtEmailAddress').val(),
                FromDate: $('#txtFromDate').val(),
                ToDate: $('#txtToDate').val()
            }
        });

        $('#btnSearch').click(function () {
            reloadGrid();
        });
    },
    reloadGrid = function () {
        $('#jqGrid').setGridParam({
            page: 1,
            url: getCandidateList,
            postData: {
                Name: $('#txtName').val(),
                EmailAddress: $('#txtEmailAddress').val(),
                FromDate: $('#txtFromDate').val(),
                ToDate: $('#txtToDate').val()
            },
        }).trigger("reloadGrid");
    };
    return {
        initializePIFormLinkRequest : initializePIFormLinkRequest,
        initializeAdminSearch: initializeAdminSearch
    }
}();