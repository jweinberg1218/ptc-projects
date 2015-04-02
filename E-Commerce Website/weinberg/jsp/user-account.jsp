<%@ include file="/jsp/header.jsp" %>
				<script type="text/javascript">
					function validateForm() {
						 var emailAddress = document.getElementById("emailAddress").value;
						 var password = document.getElementById("password").value;
						 var confirmPassword = document.getElementById("confirmPassword").value;
						 var atpos = emailAddress.indexOf("@");
						 var dotpos = emailAddress.lastIndexOf(".");

						 if (emailAddress == null || emailAddress == "") {
							 alert("You must enter an e-mail address.");
							 return false;
						 }
						 
						 if (password == null || password == "") {
							 alert("You must enter a password.");
							 return false;
						 }
						 
						 if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= emailAddress.length) {
							alert("You must enter a valid e-mail address.");
							return false;
						}
						
						if (password != confirmPassword) {
							alert("Passwords do not match.");
							return false;
						}
					 }
				</script>
				<h3>USER ACCOUNT</h3>
				<form action="/weinberg/index.jsp" method="post" onsubmit="return validateForm()">
					<h4>Customer Information</h4>
					<table>
						<tr>
							<td>First Name:</td>
							<td>
								<input name="firstName" id="firstName" type="text">
							</td>
						</tr>
						<tr>
							<td>Last Name:</td>
							<td>
								<input name="lastName" id="lastName" type="text">
							</td>
						</tr>
						<tr>
							<td>Street Address:</td>
							<td>
								<input name="streetAddress" id="streetAddress" type="text">
							</td>
						</tr>
						<tr>
							<td>City:</td>
							<td>
								<input name="city" id="city" type="text">
							</td>
						</tr>
						<tr>
							<td>State:</td>
							<td>
								<input name="state" id="state" type="text">
							</td>
						</tr>
						<tr>
							<td>Zip Code:</td>
							<td>
								<input name="zipCode" id="zipCode" type="text">
							</td>
						</tr>
					</table>
					<h4>Login Information</h4>
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
							<td>Confirm Password:</td>
							<td>
								<input name="confirmPassword" id="confirmPassword" type="password">
							</td>
						</tr>
						<tr>
							<td colspan="2" id="buttons">
								<input name="submit" type="submit" value="Save">
								<input name="reset" type="reset" value="Clear">
							</td>
						</tr>
					</table>
				</form>
<%@ include file="/jsp/footer.jsp" %>