using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// HttpServer 的摘要说明
/// </summary>
public class HttpServer
{

    /// <summary>
    /// Post方式获取数据
    /// </summary>
    /// <param name="url"></param>
    /// <param name="postData"></param>
    /// <returns></returns>
    public static string Http_POST(string url, string postData)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Referer = "http://music.163.com/";
            request.Headers.Add("Cookie", "appver=2.0.2");
            request.ContentType = "application/x-www-form-urlencoded";

            Stream myRequestStream = request.GetRequestStream();
            StreamWriter sw = new StreamWriter(myRequestStream, Encoding.ASCII);
            sw.Write(postData);
            sw.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {

                return sr.ReadToEnd().ToString();

            }
        }
        catch (Exception)
        {

            return "server error";
        }

    }

    /// <summary>
    /// Get方式获取数据
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static string Http_GET(string url)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Referer = "http://music.163.com/";
            request.Headers.Add("Cookie", "appver=2.0.2");
            request.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {

                return sr.ReadToEnd().ToString();

            }
        }
        catch (Exception)
        {

            return "server error";
        }

    }

}