<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        $(function() {

            $("#ajaxUploadForm").ajaxForm({
                iframe: true,
                dataType: "json",
                beforeSubmit: function() {
                    $("#ajaxUploadForm").block({ message: '<h1><img src="/Content/busy.gif" /> Uploading file...</h1>' });
                },
                success: function(result) {
                    $("#ajaxUploadForm").unblock();
                    $("#ajaxUploadForm").resetForm();
                    $.growlUI(null, result.message);
                },
                error: function(xhr, textStatus, errorThrown) {
                    $("#ajaxUploadForm").unblock();
                    $("#ajaxUploadForm").resetForm();
                    $.growlUI(null, 'Error uploading file');
                }
            });
        });
    </script>
    
    <form id="ajaxUploadForm" action="<%= Url.Action("AjaxUpload", "Upload")%>" method="post" enctype="multipart/form-data">
        <fieldset>
            <legend>Upload a file</legend>
            <label>File to Upload: <input type="file" name="file" />(100MB max size)</label>
            <input id="ajaxUploadButton" type="submit" value="Submit" />
            </fieldset>
    </form>
    
</asp:Content>
