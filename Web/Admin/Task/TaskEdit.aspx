<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskEdit.aspx.cs" Inherits="Maticsoft.Web.Admin.Task.TaskEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel2" runat="server" />
        <f:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" AutoScroll="true" runat="server">
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
                <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" ShowBorder="false" TabPosition="Top"
                    EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                    <Tabs>
                        <f:Tab Title="编辑信息" runat="server">

                            <Items>
                                <f:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" Height="340">

                                    <Items>

                                        <f:Form ID="SimpleForm2" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px">

                                            <Rows>
                                                <f:FormRow>
                                                    <Items>
                                                        <f:TextArea ID="txtTitle" runat="server" Label="任务标题" Height="110" Required="true" ShowRedStar="true">
                                                        </f:TextArea>
                                                    </Items>
                                                </f:FormRow>
                                                <f:FormRow>
                                                    <Items>
                                                        <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="发布时间" EmptyText="请选择日期"
                                                            ID="DateTimeTop" Required="true" ShowRedStar="true">
                                                        </f:DatePicker>

                                                    </Items>
                                                    <Items>
                                                        <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="截止时间" EmptyText="请选择日期" CompareControl="DateTimeTop"
                                                            CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" ID="DateTimeLock" Required="true" ShowRedStar="true">
                                                        </f:DatePicker>

                                                    </Items>
                                                </f:FormRow>
                                                <f:FormRow>
                                                    <Items>
                                                        <f:DropDownList runat="server" ID="drpSearch" Label="任务级别">
                                                            <f:ListItem Text="普通" Value="普通" />
                                                            <f:ListItem Text="紧急" Value="紧急" />
                                                            <f:ListItem Text="非常紧急" Value="非常紧急" />
                                                        </f:DropDownList>
                                                    </Items>
                                                </f:FormRow>
                                                <f:FormRow>
                                                    <Items>
                                                        <f:Label runat="server" Text="上传附件"></f:Label>
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

                                </f:Panel>
                            </Items>
                        </f:Tab>

                        <f:Tab Title="接收单位" runat="server">
                            <Items>
                                <f:Tree ID="TreeDpt" IsFluid="true" CssClass="blockpanel" ShowHeader="false" EnableMultiSelect="true" OnNodeCheck="TreeDpt_NodeCheck"
                                    EnableCollapse="false" runat="server" EnableCheckBox="true">
                                </f:Tree>
                            </Items>
                        </f:Tab>

                    </Tabs>

                </f:TabStrip>

            </Items>
        </f:Panel>



        <f:HiddenField runat="server" ID="hfEditorInitValue2"></f:HiddenField>
    </form>
    <script type="text/javascript" src="../../ueditor/ueditor.config.js"></script>
    <script type="text/javascript" src="../../ueditor/ueditor.all.js"></script>
    <script type="text/javascript">



        var hfEditorInitValueClientID2 = '<%= hfEditorInitValue2.ClientID %>';
        var editor2;
        F.ready(function () {

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

            if (editor2 && editor2.isReady) {
                editor2.setContent(content);
            }
        }

    </script>
</body>
</html>
