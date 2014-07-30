<%@ Page Title="Add Comment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddComment.aspx.cs" Inherits="DBT230_blog.AddComment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2> New Comment.</h2>
    <p>Type a comment and press the post button</p>
    <p>Content:
        <textarea name="content"></textarea>
    </p>
    <asp:Button ID="SubmitButton" runat="server" Text="Post Comment" />
</asp:Content>
