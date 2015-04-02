<%@ include file="/jsp/header.jsp" %>
				<script type="text/javascript">
					function validateForm() {
						var emailAddress = document.getElementById("emailAddress").value;
						var password = document.getElementById("password").value;
						var filter = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
						
						if (emailAddress == null || emailAddress == "") {
							alert("You must enter an e-mail address.");
							return false;
						}
						
						if (!filter.test(emailAddress)) {
							alert("You must enter a valid e-mail address.");
							return false;
						}
						
						if (password == null || password == "") {
							alert("You must enter a password.");
							return false;
						}
					}
				</script>
				<h3>LOGIN PAGE</h3>
				<form action="/weinberg/servlet/weinberg.Login" method="post" onsubmit="return validateForm()">
					<table>
						<tr>
							<td>E-mail Address:</td>
							<td>
								<input name="emailAddress" id="emailAddress" type="text">
							</td>
						</tr>
						<tr>
							<td>Password:</td>
							<td>
								<input name="password" id="password" type="password">
							</td>
						</tr>
						<tr>
							<td colspan="2" id="buttons">
								<input name="submit" type="submit" value="Login">
								<input name="reset" type="reset" value="Clear">
							</td>
						</tr>
					</table>
				</form>
				<a href="/weinberg/jsp/register.jsp">Click here to register!</a>
<%@ include file="/jsp/footer.jsp" %>