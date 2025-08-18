<%@ Page Title="" Language="C#" MasterPageFile="~/Settings.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">     
    <asp:UpdatePanel runat="server">
        <ContentTemplate>   
            <div class="container-fluid h-100">
  <div class="row h-100 align-items-center">                        
            <div class="col-lg-9 col-xl-8 col-xxl-7 mx-auto">
                <div class="row card-login shadow bg-white rounded mx-0 align-items-center">
                <%--<div class="col-md"><img src="images/ursImage.jpg" class="img-fluid mx-auto d-block"/></div>--%>
                     <div class="col-sm-6 p-2 p-md-4">
  <div class="login-left-div">
  <div class="login-about-panel">
  <h1>The FoodService <span>Conveyor</span> Specialists!</h1>
  <p>Aerowerks brings new solutions to the table. We specialize in the design and manufacture of material handling systems for the food industry.</p>
  <ol class="login-ol">
  <li>Aerowerks has earned a solid reputation for innovative and efficient material handling systems.</li>
 <%-- <li>Foodservice Equipment Contractors</li>
  <li>Foodservice Equipment End Users</li>--%>
  </ol>
  </div>
  </div>
  </div>
                <div class="col-sm-6 text-center p-2 p-md-4">
                    <div class="login-logo"><a href="javascript:void(0)"><img src="images/logo-aero-werks.png" alt="Aerowerks Logo" /></a></div>
  <h1>Welcome Back</h1>
  <p>Please Login to your Account</p>
                <form class="w-100 d-block validate-form">
					<%--<span class="login100-form-avatar mb-5 mx-auto col-7 col-sm-5 col-md-5">
						<img src="images/aerowerksLogo.png" class="img-fluid " />
					</span>--%>
                        <asp:DropDownList ID="ddlLoginWith" runat="server" CssClass="form-select form-select-lg mb-3" style="color:#8f8f8f">
                           <%-- <asp:ListItem>Product line</asp:ListItem>--%>
                            <asp:ListItem Value="0">Aerowerks</asp:ListItem>
                            <asp:ListItem Value="1">Gaylord</asp:ListItem>
                          <%--  <asp:ListItem Value="2">ITW</asp:ListItem>              --%>             
                        </asp:DropDownList>

                      <div class="form-floating d-flex align-items-center mb-3">
                          <asp:TextBox CssClass="form-control form-control-lg" ID="txtUserName" runat="server" AutoComplete="off" placeholder=""></asp:TextBox>

 <label for="txtUserName">User Name</label>
<span class="login-icons-size login-icons-pos position-absolute"><svg id=Layer_1 style="enable-background:new 0 0 512 512"version=1.1 viewBox="0 0 512 512"x=0px xml:space=preserve xmlns=http://www.w3.org/2000/svg xmlns:xlink=http://www.w3.org/1999/xlink y=0px><g><g><path d="M333.187,237.405c32.761-23.893,54.095-62.561,54.095-106.123C387.282,58.893,328.389,0,256,0
			S124.718,58.893,124.718,131.282c0,43.562,21.333,82.23,54.095,106.123C97.373,268.57,39.385,347.531,39.385,439.795
			c0,39.814,32.391,72.205,72.205,72.205H400.41c39.814,0,72.205-32.391,72.205-72.205
			C472.615,347.531,414.627,268.57,333.187,237.405z M164.103,131.282c0-50.672,41.225-91.897,91.897-91.897
			s91.897,41.225,91.897,91.897S306.672,223.18,256,223.18S164.103,181.954,164.103,131.282z M400.41,472.615H111.59
			c-18.097,0-32.82-14.723-32.82-32.821c0-97.726,79.504-177.231,177.231-177.231s177.231,79.504,177.231,177.231
			C433.231,457.892,418.508,472.615,400.41,472.615z"/></g></g></svg></span>
 </div>


                         
                    
                    <div class="form-floating d-flex align-items-center position-relative">
                        <asp:TextBox CssClass="form-control form-control-lg" ID="txtPassword" runat="server" TextMode="Password" AutoComplete="off" placeholder="Password (Case Sensitive)"></asp:TextBox>
				    
  <label for="txtPassword">Password (Case Sensitive)</label> 
  <span id="togglePassword" class="login-toggle-icon login-icons-size login-icons-pos position-absolute">
    <!-- Default: eye icon -->
    
<svg id="Icons" enable-background="new 0 0 128 128" height="512" viewBox="0 0 128 128" width="512" xmlns="http://www.w3.org/2000/svg"><path id="Hide" d="m79.891 65.078 7.27-7.27c.529 1.979.839 4.048.839 6.192 0 13.234-10.766 24-24 24-2.144 0-4.213-.31-6.192-.839l7.27-7.27c7.949-.542 14.271-6.864 14.813-14.813zm47.605-3.021c-.492-.885-7.47-13.112-21.11-23.474l-5.821 5.821c9.946 7.313 16.248 15.842 18.729 19.602-4.741 7.219-23.339 31.994-55.294 31.994-4.792 0-9.248-.613-13.441-1.591l-6.573 6.573c6.043 1.853 12.685 3.018 20.014 3.018 41.873 0 62.633-36.504 63.496-38.057.672-1.209.672-2.677 0-3.886zm-16.668-39.229-88 88c-.781.781-1.805 1.172-2.828 1.172s-2.047-.391-2.828-1.172c-1.563-1.563-1.563-4.094 0-5.656l11.196-11.196c-18.1-10.927-27.297-27.012-27.864-28.033-.672-1.209-.672-2.678 0-3.887.863-1.552 21.623-38.056 63.496-38.056 10.827 0 20.205 2.47 28.222 6.122l12.95-12.95c1.563-1.563 4.094-1.563 5.656 0s1.563 4.094 0 5.656zm-76.495 65.183 10.127-10.127c-2.797-3.924-4.46-8.709-4.46-13.884 0-13.234 10.766-24 24-24 5.175 0 9.96 1.663 13.884 4.459l8.189-8.189c-6.47-2.591-13.822-4.27-22.073-4.27-31.955 0-50.553 24.775-55.293 31.994 3.01 4.562 11.662 16.11 25.626 24.017zm15.934-15.935 21.809-21.809c-2.379-1.405-5.118-2.267-8.076-2.267-8.822 0-16 7.178-16 16 0 2.958.862 5.697 2.267 8.076z"/></svg>
  </span>
</div>
                    
                    <%--<div class="wrap-input100 validate-input mb-5" data-validate="Enter username">					
                        
                        <span class="focus-input100" data-placeholder="User Name"></span>
					</div>
					<div class="wrap-input100 validate-input mb-4" data-validate="Enter password">						
                         
                        <span class="focus-input100" data-placeholder="Password (Case Sensitive)"></span>		
					</div> --%>                 
					<div class="mt-3">						
                      <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-login btn-lg w-100 text-uppercase" OnClick="btnLogin_Click" />                        
					</div>
                     <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>		
				</form>
                    </div>
                </div>
            </div>
            </div>
            </div>
       </ContentTemplate>
   </asp:UpdatePanel>   
</asp:Content>