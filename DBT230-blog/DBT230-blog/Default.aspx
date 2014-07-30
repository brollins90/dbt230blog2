<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DBT230_blog._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        
        <% foreach (CassandraBlogStuff.Post current in posts)
           {
               Response.Write(string.Format("<p><a href='P.aspx?id={0}'>{1} <br/> -- {2}</a></p>",current.postid, current.ToString(), current.poster));
           } %>
    </div>


</asp:Content>
