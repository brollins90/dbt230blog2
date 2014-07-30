<%@ Page Title="Add Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPost.aspx.cs" Inherits="DBT230_blog.AddPost" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2> New Post</h2>
    <p>Write your blog post</p>
    <div>Title:</div>
    <div>
        <textarea name="title" cols="80" rows="5"></textarea>
    </div>
    <div>Content:</div>
    <div>
        <textarea name="content" cols="80" rows="20"></textarea>
    </div>
    <asp:Button ID="SubmitButton" runat="server" Text="Create Post" />
</asp:Content>
