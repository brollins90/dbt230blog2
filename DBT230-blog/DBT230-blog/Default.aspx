<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DBT230_blog._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        
        <% foreach (string current in titles)
           {
               Response.Write(string.Format("<p>{0}</p>",current));
           } %>
        <% foreach (CassandraBlogStuff.Post current in posts)
           {
               Response.Write(string.Format("<p>{0}</p>",current.ToString()));
           } %>
    </div>


</asp:Content>
