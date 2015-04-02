<%@ include file="/jsp/header.jsp" %>
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
				<h3>CART PAGE</h3>
				<p>There are currently <strong>4 items</strong> in your cart.</p>
				<form action="#" method="post" onsubmit="return validateForm()">
					<div id="buttons">
						<input name="submit" id="submit" type="submit" value="Update Item Quantity">
						<input name="submit" id="submit" type="submit" value="Delete Selected Items">
					</div>
					<br>
					<table id="searchResults">
						<tr class="searchResults">
							<th class="searchResults"></th>
							<th class="searchResults">Image</th>
							<th class="searchResults">Qty</th>
							<th class="searchResults">Name</th>
							<th class="searchResults">Description</th>
							<th class="searchResults">Price</th>
						</tr>
						<tr class="searchResults">
							<td class="searchResults">
								<input name="item1" id="item" type="checkbox">
							</td>
							<td class="searchResults">
								<img src="/weinberg/images/books.png" id="books">
							</td>
							<td class="searchResults">
								<input name="qty" type="text" value="1" id="qty">
							</td>
							<td class="searchResults">
								<a href="#">Item1</a>
							</td>
							<td class="searchResults" id="description">
								Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
								Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
								Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
								Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
							</td>
							<td class="searchResults">$9.99</td>
						</tr>
						<tr class="searchResults">
							<td class="searchResults">
								<input name="item2" id="item" type="checkbox">
							</td>
							<td class="searchResults">
								<img src="/weinberg/images/books.png" id="books">
							</td>
							<td class="searchResults">
								<input name="qty" type="text" value="1" id="qty">
							</td>
							<td class="searchResults">
								<a href="#">Item2</a>
							</td>
							<td class="searchResults" id="description">
								Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
								Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
								Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
								Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
							</td>
							<td class="searchResults">$9.99</td>
						</tr>
						<tr class="searchResults">
							<td class="searchResults">
								<input name="item3" id="item" type="checkbox">
							</td>
							<td class="searchResults">
								<img src="/weinberg/images/books.png" id="books">
							</td>
							<td class="searchResults">
								<input name="qty" type="text" value="1" id="qty">
							</td>
							<td class="searchResults">
								<a href="#">Item3</a>
							</td>
							<td class="searchResults" id="description">
								Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
								Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
								Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
								Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
							</td>
							<td class="searchResults">$9.99</td>
						</tr>
						<tr class="searchResults">
							<td class="searchResults">
								<input name="item4" id="item" type="checkbox">
							</td>
							<td class="searchResults">
								<img src="/weinberg/images/books.png" id="books">
							</td>
							<td class="searchResults">
								<input name="qty" type="text" value="1" id="qty">
							</td>
							<td class="searchResults">
								<a href="#">Item4</a>
							</td>
							<td class="searchResults" id="description">
								Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
								Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
								Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
								Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
							</td>
							<td class="searchResults">$9.99</td>
						</tr>
					</table>
					<br>
					<div id="buttons">
						<input name="submit" id="submit" type="submit" value="Update Item Quantity">
						<input name="submit" id="submit" type="submit" value="Delete Selected Items">
					</div>
				</form>
					<br>
				<form action="#" method="post">
					<div id="price">
						Subtotal: <strong>$39.96</strong><br>
						Tax: <strong>$0.80</strong><br>
						Total: <strong>$40.76</strong><br>
						<br>
						<input name="submit" id="submit" type="submit" value="Checkout">
					</div>
				</form>
<%@ include file="/jsp/footer.jsp" %>