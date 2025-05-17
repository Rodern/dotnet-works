using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeMall.Models.Helpers
{
	public static class HTMLMarkupConstructor
	{
		public static string GetResetEmailTemplate(string link, string baseUrl)
		{
			return $@"<!doctype html>
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml""
	xmlns:o=""urn:schemas-microsoft-com:office:office"">

<head>
	<title>

	</title>
	<!--[if !mso]><!-- -->
	<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
	<!--<![endif]-->
	<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
	<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
	<style type=""text/css"">
		:root {{
			--app-primary-color: #25472c;
			--app-secondary-color: #6A0DAD;
			--app-tertiary-color: #FF2E49;
			--app-utinary-color: #F60076;
			--app-denary-color: #D3189E;
			--app-accent-color: #3E51CC;
			--app-primary-hover-color: #E54E02;
			--app-secondary-hover-color: #5A0B92;
			--app-tertiary-hover-color: #FF0325;
			--app-utinary-hover-color: #D20065;
			--app-denary-hover-color: #B51487;
			--app-accent-hover-color: #3041B4;
			--app-primary-focus-color: #AC3B02;
			--app-secondary-focus-color: #4B097A;
			--app-tertiary-focus-color: #D7001D;
			--app-utinary-focus-color: #AF0055;
			--app-denary-focus-color: #971171;
			--app-accent-focus-color: #283696;

			--app-text-black-color: #000000;
			--app-text-dark-color: #333333;
			--app-text-charcoal-color: #4A4A4A;
			--app-text-slate-gray-color: #2E2E2E;
			--app-text-navy-blue-color: #000080;
		}}

		#outlook a {{
			padding: 0;
		}}

		.ReadMsgBody {{
			width: 100%;
		}}

		.ExternalClass {{
			width: 100%;
		}}

		.ExternalClass * {{
			line-height: 100%;
		}}

		body {{
			margin: 0;
			padding: 0;
			-webkit-text-size-adjust: 100%;
			-ms-text-size-adjust: 100%;
		}}

		table,
		td {{
			border-collapse: collapse;
			mso-table-lspace: 0pt;
			mso-table-rspace: 0pt;
		}}

		img {{
			border: 0;
			height: auto;
			line-height: 100%;
			outline: none;
			text-decoration: none;
			-ms-interpolation-mode: bicubic;
		}}

		p {{
			display: block;
			margin: 13px 0;
		}}
	</style>
	<!--[if !mso]><!-->
	<style type=""text/css"">
		@media only screen and (max-width:480px) {{
			@-ms-viewport {{
				width: 320px;
			}}

			@viewport {{
				width: 320px;
			}}
		}}
	</style>
	<!--<![endif]-->
	<!--[if mso]>
		<xml>
		<o:OfficeDocumentSettings>
		  <o:AllowPNG/>
		  <o:PixelsPerInch>96</o:PixelsPerInch>
		</o:OfficeDocumentSettings>
		</xml>
		<![endif]-->
	<!--[if lte mso 11]>
		<style type=""text/css"">
		  .outlook-group-fix {{ width:100% !important; }}
		</style>
		<![endif]-->


	<style type=""text/css"">
		@media only screen and (min-width:480px) {{
			.mj-column-per-100 {{
				width: 100% !important;
			}}
		}}
	</style>


	<style type=""text/css"">
	</style>

</head>

<body style=""background-color:#f9f9f9;"">


	<div style=""background-color:#f9f9f9;"">


		<!--[if mso | IE]>
	  <table
		 align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width:600px;"" width=""600""
	  >
		<tr>
		  <td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;"">
	  <![endif]-->


		<div style=""background:#f9f9f9;background-color:#f9f9f9;Margin:0px auto;max-width:600px;"">

			<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation""
				style=""background:#f9f9f9;background-color:#f9f9f9;width:100%;"">
				<tbody>
					<tr>
						<td
							style=""border-bottom:#333957 solid 5px;direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;"">
							<!--[if mso | IE]>
				  <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">

		<tr>

		</tr>

				  </table>
				<![endif]-->
						</td>
					</tr>
				</tbody>
			</table>

		</div>


		<!--[if mso | IE]>
		  </td>
		</tr>
	  </table>

	  <table
		 align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width:600px;"" width=""600""
	  >
		<tr>
		  <td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;"">
	  <![endif]-->


		<div style=""background:#fff;background-color:#fff;Margin:0px auto;max-width:600px;"">

			<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation""
				style=""background:#fff;background-color:#fff;width:100%;"">
				<tbody>
					<tr>
						<td
							style=""border:#dddddd solid 1px;border-top:0px;direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;"">
							<!--[if mso | IE]>
				  <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">

		<tr>

			<td
			   style=""vertical-align:bottom;width:600px;""
			>
		  <![endif]-->

							<div class=""mj-column-per-100 outlook-group-fix""
								style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:bottom;width:100%;"">

								<table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation""
									style=""vertical-align:bottom;"" width=""100%"">

									<tr>
										<td align=""center""
											style=""font-size:0px;padding:10px 25px;word-break:break-word;"">

											<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0""
												role=""presentation""
												style=""border-collapse:collapse;border-spacing:0px;"">
												<tbody>
													<tr>
														<td style=""width:200px;"">

															<img height=""auto""
																src=""{{baseUrl}}_content/BridgeMall.SHARED.UI/assets/images/logofinal_01.svg""
																style=""border:0;display:block;outline:none;text-decoration:none;width:100%;""
																width=""64"" />

														</td>
													</tr>
												</tbody>
											</table>

										</td>
									</tr>

									<tr>
										<td align=""center""
											style=""font-size:0px;padding:10px 25px;padding-bottom:40px;word-break:break-word;"">

											<div
												style=""font-family:'Segoe UI Variable', 'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:38px;font-weight:bold;line-height:1;text-align:center;color:#555;"">
												Oops!
											</div>

										</td>
									</tr>

									<tr>
										<td align=""center""
											style=""font-size:0px;padding:10px 25px;padding-bottom:40px;word-break:break-word;"">

											<div
												style=""font-family:'Segoe UI Variable', 'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:18px;line-height:1;text-align:center;color:#555;"">
												It seems that you’ve forgotten your password.
											</div>

										</td>
									</tr>

									<tr>
										<td align=""center""
											style=""font-size:0px;padding:10px 25px;padding-top:30px;padding-bottom:50px;word-break:break-word;"">

											<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0""
												role=""presentation"" style=""border-collapse:separate;line-height:100%;"">
												<tr>
													<td align=""center"" bgcolor=""#25472c"" role=""presentation""
														style=""border:none;border-radius:3px;color:#ffffff;cursor:auto;padding:15px 25px;""
														valign=""middle"">
														<a href=""{{link}}""
															style=""background:var(--app-primary-color);color:#ffffff;font-family:'Segoe UI Variable', 'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:15px;font-weight:bold;line-height:120%;Margin:0;text-decoration:none;text-transform:none;"">
															Reset Password
														</a>
													</td>
												</tr>
											</table>

										</td>
									</tr>

									<tr>
										<td align=""center""
											style=""font-size:0px;padding:10px 25px;padding-bottom:40px;word-break:break-word;"">

											<div
												style=""font-family:'Segoe UI Variable', 'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:16px;line-height:20px;text-align:center;color:#7F8FA4;"">
												If you did not make this request, just ignore this email. Otherwise
												please click the button above to reset your password.
											</div>

										</td>
									</tr>

								</table>

							</div>

							<!--[if mso | IE]>
			</td>

		</tr>

				  </table>
				<![endif]-->
						</td>
					</tr>
				</tbody>
			</table>

		</div>


		<!--[if mso | IE]>
		  </td>
		</tr>
	  </table>

	  <table
		 align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width:600px;"" width=""600""
	  >
		<tr>
		  <td style=""line-height:0px;font-size:0px;mso-line-height-rule:exactly;"">
	  <![endif]-->

		<div style=""Margin:0px auto;max-width:600px;"">

			<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width:100%;"">
				<tbody>
					<tr>
						<td style=""direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;"">
							<!--[if mso | IE]>
				  <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">

		<tr>

			<td
			   style=""vertical-align:bottom;width:600px;""
			>
		  <![endif]-->

							<div class=""mj-column-per-100 outlook-group-fix""
								style=""font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:bottom;width:100%;"">

								<table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" width=""100%"">
									<tbody>
										<tr>
											<td style=""vertical-align:bottom;padding:0;"">

												<table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation""
													width=""100%"">

													<tr>
														<td align=""center""
															style=""font-size:0px;padding:0;word-break:break-word;"">

															<div
																style=""font-family:'Segoe UI Variable', 'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:12px;font-weight:300;line-height:1;text-align:center;color:#575757;"">
																Cameroon (CM), Africa
															</div>

														</td>
													</tr>

												</table>

											</td>
										</tr>
									</tbody>
								</table>

							</div>

							<!--[if mso | IE]>
			</td>

		</tr>

				  </table>
				<![endif]-->
						</td>
					</tr>
				</tbody>
			</table>

		</div>


		<!--[if mso | IE]>
		  </td>
		</tr>
	  </table>
	  <![endif]-->


	</div>

</body>

</html>";
		}
	}
}
