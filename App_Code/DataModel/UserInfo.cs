using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserInfo 的摘要说明
/// </summary>
public class UserInfo
{
    private string id;

    private string pname;

    private string sex;

    private string email;

    private string password;

    private long dataob;

    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Pname
    {
        get
        {
            return pname;
        }

        set
        {
            pname = value;
        }
    }

    public string Sex
    {
        get
        {
            return sex;
        }

        set
        {
            sex = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public long Dataob
    {
        get
        {
            return dataob;
        }

        set
        {
            dataob = value;
        }
    }
}