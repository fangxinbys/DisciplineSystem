<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopicEdit.aspx.cs" Inherits="Maticsoft.Web.Admin.Topic.TopicEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" AutoScroll="true" runat="server">
            <Toolbars>
                <f:Toolbar ID="toolbar" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                            Text="关闭">
                        </f:Button>
                        <f:ToolbarSeparator ID="toolbarSe" runat="server">
                        </f:ToolbarSeparator>
                        <f:Button ID="btnSaveClose" ValidateForms="SimpleForm1,SimpleForm2" Icon="SystemSaveClose" OnClick="btnSaveClose_Click"
                            runat="server" Text="保存后关闭">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:GroupPanel runat="server" Title="基本信息" ID="GroupPanel1"  EnableCollapse="true" Collapsed="true">
                    <Items>
                        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px">

                            <Rows>

                                <f:FormRow>
                                    <Items>
                                        <f:TextBox ID="txtDptName" runat="server" Label="单位名称" Required="true" ShowRedStar="true">
                                        </f:TextBox>

                                    </Items>
                                </f:FormRow>
                                <f:FormRow>
                                    <Items>
                                        <f:TextBox ID="txtTitle" runat="server" Label="议题名称" Required="true" ShowRedStar="true">
                                        </f:TextBox>
                                    </Items>
                                    <Items>
                                        <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="提出时间" EmptyText="请选择日期"
                                            ID="DateTimeCh" Required="true" ShowRedStar="true">
                                        </f:DatePicker>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow>
                                    <Items>
                                        <f:ContentPanel runat="server" ID="contentpan" ShowBorder="false" ShowHeader="false">
                                            <textarea name="editorNew" id="editorNew">  </textarea>
                                        </f:ContentPanel>
                                    </Items>
                                </f:FormRow>


                            </Rows>
                        </f:Form>
                    </Items>
                </f:GroupPanel>

            </Items>
            <Items>
                <f:GroupPanel runat="server" Title="集体决策情况" ID="GroupPanel2"  EnableCollapse="true" Height="400">
                    <Items>
                        <f:Form ID="SimpleForm2" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px">

                            <Rows>

                                <f:FormRow>
                                    <Items>
                                        <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="决策时间" EmptyText="请选择日期"
                                            ID="DateTimeTop" Required="true" ShowRedStar="true">
                                        </f:DatePicker>

                                    </Items>
                                    <Items>
                                        <f:TextBox ID="txtAdress" runat="server" Label="决策地点" Required="true" ShowRedStar="true">
                                        </f:TextBox>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow>
                                    <Items>
                                        <f:TextArea ID="txtPeo" runat="server" Label="参会人员" Height="50" Required="true" ShowRedStar="true">
                                        </f:TextArea>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow>
                                    <Items>
                                        <f:TextArea ID="txtProcess" runat="server" Label="决策过程" Height="50" Required="true" ShowRedStar="true">
                                        </f:TextArea>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow>
                                    <Items>
                                        <f:TextArea ID="txtRs" runat="server" Label="决策结论" Height="50" Required="true" ShowRedStar="true">
                                        </f:TextArea>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow>
                                    <Items>
                                        <f:TextArea ID="txtDone" runat="server" Label="执行情况" Height="50" Required="true" ShowRedStar="true">
                                        </f:TextArea>
                                    </Items>
                                </f:FormRow>
                                 <f:FormRow>
                                    <Items>
                                        <f:ContentPanel runat="server" ID="ContentPanelTwo" ShowBorder="false" ShowHeader="false">
                                            <textarea name="editorNew2" id="editorNew2">  </textarea>
                                        </f:ContentPanel>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                    </Items>
                </f:GroupPanel>

            </Items>
        </f:Panel>

        <f:HiddenField runat="server" ID="hfEditorInitValue"></f:HiddenField>
        <f:HiddenField runat="server" ID="hfEditorInitValue2"></f:HiddenField>
    </form>
    <script type="text/javascript" src="../../ueditor/ueditor.config.js"></script>
    <script type="text/javascript" src="../../ueditor/ueditor.all.js"></script>
    <script type="text/javascript">


        var hfEditorInitValueClientID = '<%= hfEditorInitValue.ClientID %>';
        var editor;var editor2;
        F.ready(function () {
            editor = UE.getEditor('editorNew', {
                toolbars: [['attachment']],
                initialFrameWidth: '100%',
                initialFrameHeight: '50',
                autoHeightEnabled: false,
                autoFloatEnabled: false,
                focus: false,
                onready: function () {
                    var editorInitValue = F('hfEditorInitValue').getValue();
                    if (editorInitValue) {
                        this.setContent(editorInitValue);
                    }

                }
            });
            editor2 = UE.getEditor('editorNew2', {
                toolbars: [['attachment']],
                initialFrameWidth: '100%',
                initialFrameHeight: '50',
                autoHeightEnabled: false,
                autoFloatEnabled: false,
                focus: false,
                onready: function () {
                    var editorInitValue = F('hfEditorInitValue2').getValue();
                    if (editorInitValue) {
                        this.setContent(editorInitValue);
                    }

                }
            });
        });


        function updateEditor(content) {
            if (editor && editor.isReady) {
                editor.setContent(content);
            }
             if (editor2 && editor2.isReady) {
                editor2.setContent(content);
            }
        }

    </script>
</body>
</html>
