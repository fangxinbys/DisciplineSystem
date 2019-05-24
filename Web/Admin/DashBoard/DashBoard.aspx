<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="Maticsoft.Web.Admin.DashBoard.DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script src="../../res/js/echarts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel2" />
        <f:Panel ID="Panel2" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="true"
            Layout="VBox" ShowHeader="false" Title="面板（改变页面大小来观察面板的变化）">
            <Items>
                <f:Panel ID="Panel1" BoxFlex="1" runat="server"
                    ShowBorder="false" ShowHeader="false" Layout="HBox" BoxConfigChildMargin="0 5 0 0" MarginBottom="5">
                    <Items>
                        <f:ContentPanel ID="ContentPanel1" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" AutoScroll="true">


                            <div id="main" style="width: 500px; height: 370px;"></div>
                            <script type="text/javascript">
                                // 基于准备好的dom，初始化echarts实例
                                var myChart = echarts.init(document.getElementById('main'));

                                // 指定图表的配置项和数据
                                var option = {
                                    title: {
                                        text: '周处理文件统计'
                                    },
                                    tooltip: {},
                                    legend: {
                                        data: ['数量']
                                    },
                                    xAxis: {
                                        data: ["监督文件", "考核文件", "上报文件", "反馈文件", "绩效文件", "考勤文件"]
                                    },
                                    yAxis: {},
                                    series: [{
                                        name: '数量',
                                        type: 'bar',
                                        data: [5, 20, 36, 10, 10, 20]
                                    }]
                                };

                                // 使用刚指定的配置项和数据显示图表。
                                myChart.setOption(option);
                            </script>

                        </f:ContentPanel>
                        <f:ContentPanel ID="ContentPane2" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false">
                            <div id="main2" style="width: 500px; height: 370px;"></div>
                            <script>
                                // 绘制图表。
                                echarts.init(document.getElementById('main2')).setOption({
                                    title: {
                                        text: '学历统计'
                                    },
                                    series: {

                                        type: 'pie',
                                        data: [
                                            { name: '博士', value: 1212 },
                                            { name: '研究生', value: 2323 },
                                            { name: '本科', value: 1919 }
                                        ]
                                    }
                                });
                            </script>
                        </f:ContentPanel>
                        <f:ContentPanel ID="ContentPane3" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" Margin="0">
                            <div id="container" style="width: 500px; height: 370px;"></div>


                            <script type="text/javascript">
                                var dom = document.getElementById("container");
                                var myChart = echarts.init(dom);
                                var app = {};
                                option = null;
                                option = {
                                      title: {
                                        text: '监察舆情'
                                    },
                                    xAxis: {
                                        type: 'category',
                                        data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
                                    },
                                    yAxis: {
                                        type: 'value'
                                    },
                                    series: [{
                                        data: [820, 932, 901, 934, 1290, 1330, 1320],
                                        type: 'line',
                                        smooth: true
                                    }]
                                };
                                ;
                                if (option && typeof option === "object") {
                                    myChart.setOption(option, true);
                                }
                            </script>
                        </f:ContentPanel>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel5" BoxFlex="1" runat="server"
                    ShowBorder="false" ShowHeader="false" Layout="HBox" BoxConfigChildMargin="0 5 0 0">
                    <Items>
                        <f:ContentPanel ID="ContentPane4" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="true" Title="最新通知">
                        </f:ContentPanel>
                        <f:ContentPanel ID="ContentPane5" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="true" Title="政策法规">
                        </f:ContentPanel>
                        <f:ContentPanel ID="ContentPane6" BoxFlex="1" runat="server" ShowBorder="true" Margin="0" ShowHeader="true" Title="学习文件">
                        </f:ContentPanel>
                    </Items>
                </f:Panel>

            </Items>
        </f:Panel>

    </form>
</body>

</html>
