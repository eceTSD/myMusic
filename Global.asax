<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {


        // 在应用程序启动时运行的代码
        ////定义定时器  
        ////在应用程序启动时运行的代码 这里设置34个小时间隔 43200000 12小时  60000 一分钟
        System.Timers.Timer myTimer = new System.Timers.Timer(60000);
        //修改时间间隔
        //关联事件
        myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
        myTimer.AutoReset = true;
        myTimer.Enabled = true;

    }
    ///// <summary>
    ///// 定时执行的代码
    ///// </summary>
    private void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        MyInit.initHome();
    }

    void Application_End(object sender, EventArgs e)
    {

        ////在应用程序关闭时运行的代码
        ////保存当前访问


        //可解决IIS应用程序池自动回收的问题  
        string url = "http://10.4.3.4:1811/mystation/mymusic/";
        System.Net.HttpWebRequest myHttpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
        System.Net.HttpWebResponse myHttpWebResponse = (System.Net.HttpWebResponse)myHttpWebRequest.GetResponse();
        System.IO.Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流

    }


    void Application_Error(object sender, EventArgs e)
    {
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e)
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
        // 或 SQLServer，则不引发该事件。

    }

</script>
