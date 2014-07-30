<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DBT230_blog._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        
        <% foreach (CassandraBlogStuff.Post current in posts)
           {
               string htmlPost = string.Format("<div class='blogpostdefault'>" +
                   "<a href='P.aspx?id={4}'><div class='posttitledefault'>{0}</div></a>" +
                   "<div class='posttimedefault'>{1:MM/dd/yyyy hh:mm t}M</div>" +
                   "<div class='postcontentdefault'>{2}</div>" +
                   "<div class='posterdefault'>{3}</div>" +
                   "</div><hr>",
                   current.posttitle, current.posttime.ToLocalTime(), current.content, current.poster, current.postid);
               Response.Write(htmlPost);
               //Response.Write(string.Format("<p><a href='P.aspx?id={0}'>{1} <br/> -- {2}</a></p>",current.postid, current.ToString(), current.poster));
           } %>
    </div>


</asp:Content>
