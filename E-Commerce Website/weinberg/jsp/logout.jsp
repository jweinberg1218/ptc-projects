<%
	HttpSession httpSession2 = request.getSession();

	httpSession2.setAttribute("credentials", null);
%>

<%@ include file="/jsp/header.jsp" %>
				You have successfully logged out!<br>
				<br>
				<a href="/weinberg/index.jsp">Click here to return to the home page!</a>
<%@ include file="/jsp/footer.jsp" %>