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

        $('#btnSearch').click(function () {
            loadGrid();
        });
    },
    loadGrid = function () {

        $('#jqGrid').jqGrid({
            url: getCandidateList,
            datatype: "json",
            colModel: [
	                { name: 'CandidateId', key: true, width: 25, resizable: false, sortable: false, hidden: true },
	                { name: 'CandidateName', key: true, width: 220, resizable: false, sortable: false, hidden: false },
	                { name: 'CandidateEmail', key: true, width: 220, resizable: false, sortable: false, hidden: false },
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