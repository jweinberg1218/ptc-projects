<%@ page import="java.io.*" %>
<%@ page import="javax.servlet.*" %>
<%@ page import="javax.servlet.http.*" %>
<%@ page import="weinberg.beans.*" %>

<%
	String header1, header2;

	HttpSession httpSession = request.getSession();

	Credentials credentials = (Credentials)httpSession.getAttribute("credentials");

	if(credentials == null) {
		header1 = "Welcome, Guest!";
		header2 = "<a href=\"/weinberg/jsp/login.jsp\">Login</a> | <a href=\"/weinberg/jsp/register.jsp\">Register</a>";
	}

	else {
		header1 = "Welcome back, " + credentials.getEmailAddress() + "!";
		header2 = "<a href=\"/weinberg/jsp/user-account.jsp\">User Account</a> | <a href=\"/weinberg/jsp/logout.jsp\">Log Out</a>";
	}
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<title>Jason's E-Store</title>
		<link rel="stylesheet" type="text/css" href="/weinberg/css/stylesheet.css">
	</head>
	<body>
		<center>
				<h1>Jason's E-Store</h1>
				<ul>
					<li><a href="/weinberg/index.jsp" class="menuItem">Home</a></li>
					<li><a href="/weinberg/jsp/login.jsp" class="menuItem">Login</a></li>
					<li><a href="/weinberg/jsp/register.jsp" class="menuItem">Register</a></li>
					<li><a href="/weinberg/jsp/search.jsp" class="menuItem">Search</a></li>
					<li><a href="/weinberg/jsp/cart.jsp" class="menuItem">Cart</a></li>
				</ul>
				<p>
					<%= header1 %><br>
					<%= header2 %>
				</p>
				<div id="content">