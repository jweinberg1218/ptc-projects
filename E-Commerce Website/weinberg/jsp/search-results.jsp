<%@ include file="/jsp/header.jsp" %>
				<jsp:useBean id="search" scope="session" class="weinberg.Search" />
				<script type="text/javascript">
					function validateForm() {						
						var item = document.getElementById("item").checked;
						
						if (!item)
						{
							alert("You must check at least one item.");
							return false;
						}
					 }
				</script>
				<h3>SEARCH RESULTS PAGE</h3>
				<form action="#" method="post" onsubmit="return validateForm()">
					<div id="buttons">
						<input name="submit" type="submit" value="Add Selected Items to Cart">
					</div>
					<br>
					<table id="searchResults">
						<tr class="searchResults">
							<th class="searchResults"></th>
							<th class="searchResults">Image</th>
							<th class="searchResults">Name</th>
							<th class="searchResults">Description</th>
						</tr>
						
						<% for (weinberg.beans.Book book : search.getBook()) { %>
						<tr class="searchResults">
							<td class="searchResults">
								<input name="item1" id="item" type="checkbox">
							</td>
							<td class="searchResults">
								<img src="/weinberg/images/cover-art/<% book.getCoverArt(); %>" id="books">
							</td>
							<td class="searchResults">
								<a href="#"><%= book.getTitle() %></a>
							</td>
							<td class="searchResults" id="description">
								<%= book.getDescription() %>
							</td>
						</tr>
						<% } %>
					</table>
					<br>
					<div id="buttons">
						<input name="submit" type="submit" value="Add Selected Items to Cart">
					</div>
				</form>
<%@ include file="/jsp/footer.jsp" %>