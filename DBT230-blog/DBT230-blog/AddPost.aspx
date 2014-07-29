<%@ Page Title="Add Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPost.aspx.cs" Inherits="DBT230_blog.AddPost" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <p><%: temp %></p>
    <p>Title:
        <textarea name="title"></textarea>
    </p>
    <p>Content:
        <textarea name="content"></textarea>
    </p>
    <asp:Button ID="SubmitButton" runat="server" Text="Create Post" />
</asp:Content>
