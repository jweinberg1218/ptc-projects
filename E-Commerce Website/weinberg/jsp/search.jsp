<%@ include file="/jsp/header.jsp" %>
				<script type="text/javascript">
					function validateForm() {
						 var searchQuery = document.getElementById("searchQuery").value;

						 if (searchQuery == null || searchQuery == "") {
							 alert("You must enter a search query.");
							 return false;
						 }
					 }
				</script>
				<h3>SEARCH PAGE</h3>
				<form action="/weinberg/servlet/weinberg.Search" method="post" onsubmit="return validateForm()">
					<table>
						<tr>
							<td>Search Query:</td>
							<td><input name="searchQuery" id="searchQuery" type="text"></td>
							<td>
								<select name="criteria">
									<option value="author">Author</option>
									<option value="volumeTitle">Volume Title</option>
									<option value="isbn">ISBN</option>
								</select>
						<tr>
							<td colspan="3" id="buttons">
								<input name="submit" type="submit" value="Search">
								<input name="reset" type="reset" value="Clear">
							</td>
						</tr>
					</table>
				</form>
<%@ include file="/jsp/footer.jsp" %>