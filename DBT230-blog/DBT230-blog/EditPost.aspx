<%@ Page Title="Edit Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="DBT230_blog.EditPost" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2> Edit Post</h2>
    <p>Write your blog post</p>
    <div>Title:</div>
    <div>
        <textarea name="title" id="title" cols="80" rows="5" runat="server"></textarea>
    </div>
    <div>Content:</div>
    <div>
        <textarea name="content" id="content" cols="80" rows="20" runat="server"></textarea>
        <textarea name="posttime" id="posttime" runat="server" style="visibility:hidden" ></textarea>
    </div>

    <asp:Button ID="SubmitButton" runat="server" Text="EDIT!" />
</asp:Content>
