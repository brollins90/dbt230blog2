<%@ Page Title="Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="P.aspx.cs" Inherits="DBT230_blog.P" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: daPost.posttitle %></h2>
    <p><%: daPost.content %></p>
    <p><a href='AddComment.aspx?id=<%: daPost.postid %>'>Add a comment</a></p>
</asp:Content>
