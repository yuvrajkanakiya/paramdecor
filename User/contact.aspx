<%@ Page Title="" Language="C#" MasterPageFile="~/Content/UserMasterPage.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="AdminPanel_contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- Start Contact Area -->
        <section class="wn_contact_area bg--white pt--80 pb--80">
			<div class="google__map pb--80 embed-responsive embed-responsive-16by9">
				<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3708.604701165192!2d69.6083180140601!3d21.64032208567033!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x395635889b518025%3A0x26a0ae2cced87093!2sParam%20Decor%20%26%20Graphics!5e0!3m2!1sen!2sin!4v1615263746514!5m2!1sen!2sin"></iframe>
        	</div>
        	<div class="container">
        		<div class="row" style="padding-top:80px;">
        			<div class="col-lg-8 col-12">
        				<div class="contact-form-wrap">
        					<div class="wn__address">
        					<h2 class="contact__title">Address</h2>        					
        					<div class="wn__addres__wreapper">

        						<div class="single__address">
        							<i class="icon-location-pin icons"></i>
        							<div class="content">
        								<span>address:</span>
        								<p>Panjarapor, HMP Colony Rd, Porbandar, Gujarat 360575</p>
        							</div>
        						</div>

        						<div class="single__address">
        							<i class="icon-phone icons"></i>
        							<div class="content">
        								<span>Phone Number:</span>
        								<p>099787 01390</p>
        							</div>
        						</div>

        						<div class="single__address">
        							<i class="icon-envelope icons"></i>
        							<div class="content">
        								<span>Email address:</span>
        								<p>niluparam@gmail.com</p>
        							</div>
        						</div>

        						
        					</div>
        				</div>
        					
                        </div> 
                        <div class="form-output">
                            <p class="form-messege">
                        </div>
        			</div>
        			<div class="col-lg-4 col-12 md-mt-40 sm-mt-40">
        				<div class="wn__address">
        					<h2 class="contact__title">Get office info.</h2>
        					<p>Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. </p>
        					
        				</div>
        			</div>
        		</div>
        	</div>
        </section>
        <!-- End Contact Area -->

</asp:Content>

