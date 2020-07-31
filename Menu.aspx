<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FtcTimeSystem.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>NTMC出退勤システム</title>
<!--                       CSS                       -->
<!-- Reset Stylesheet -->
<link rel="stylesheet" href="resources/css/reset.css" type="text/css" media="screen" />
<!-- Main Stylesheet -->
<link rel="stylesheet" href="resources/css/style.css" type="text/css" media="screen" />
<!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
<link rel="stylesheet" href="resources/css/invalid.css" type="text/css" media="screen" />
<!--                       Javascripts                       -->
<!-- jQuery -->
<script type="text/javascript" src="resources/scripts/jquery-1.3.2.min.js"></script>
<!-- jQuery Configuration -->
<script type="text/javascript" src="resources/scripts/simpla.jquery.configuration.js"></script>

<!-- jQuery WYSIWYG Plugin -->
<script type="text/javascript" src="resources/scripts/jquery.wysiwyg.js"></script>
<!-- jQuery Datepicker Plugin -->
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/South-Street/jquery-ui.css"/>
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script src="resources/scripts/datepicker-ja.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {
          $('#datepicker1').datepicker();
          $('#datepicker2').datepicker();
      });
</script>
   <script>
       $(function () {
           $("#datepicker").datepicker({
               dateFormat: 'yy/mm/dd',
               constrainInput: true
           });
       });
  </script>


    <style type="text/css">
        .auto-style1 {
            width: 159px;
        }
        .auto-style2 {
            width: 154px;
        }
        .auto-style3 {
            width: 48px;
        }
    </style>


</head>
<body style="position:relative">
<form id="form1" runat="server">
<div id="body-wrapper" style="position:absolute">
  <!-- Wrapper for the radial gradient background -->
  <div id="sidebar">
    <div id="sidebar-wrapper">
      <!-- Sidebar with logo and menu -->
      <h1 id="sidebar-title"><a href="#">Simpla Admin</a></h1>
      <!-- Logo (221px wide) -->
      <a href="#"><img id="logo" src="resources/images/logo.png" alt="Simpla Admin logo" /></a>
      <!-- Sidebar Profile links -->
      <div id="profile-links"> 名前 <a href="#" title="Edit your profile">部門</a>, 社員番号 <a>
          <asp:Label ID="userid" runat="server" ></asp:Label></a><br />
        <br />
        <a href="#" title="View the Site"></a> <a>
            <asp:LinkButton ID="Logout" runat="server" OnClick="Logout_Click">ログアウト</asp:LinkButton></a> </div>
      <ul id="main-nav">
        <!-- Accordion Menu -->
        <li> <a href="#" class="nav-top-item"> 出勤時間検索 </a>
          <ul>
            <li><asp:LinkButton ID="AttendanceData" runat="server" OnClick="AttendanceData_Click">月単位検索</asp:LinkButton></li>
            

            <li><asp:LinkButton ID="AttendanceDay" runat="server" OnClick="AttendanceDay_Click">日単位検索</asp:LinkButton></li>
          </ul>
        </li>
        <li> <a href="#" class="nav-top-item"> 届出処理 </a>
          <ul>
            <li><asp:LinkButton ID="Apply" runat="server"　OnClick="Apply_Click">残業届出</asp:LinkButton></li>
          </ul>
        </li>
    <li> <a href="#" class="nav-top-item"> 承認処理 </a>
          <ul>
            <li><asp:LinkButton ID="Approve" runat="server"　OnClick="Approve_Click">残業承認</asp:LinkButton></li>
          </ul>
        </li>
    <!--        <li> <a href="#" class="nav-top-item"> Settings </a>
          <ul>
            <li><a href="#">General</a></li>
            <li><a href="#">Design</a></li>
            <li><a href="#">Your Profile</a></li>
            <li><a href="#">Users and Permissions</a></li>
          </ul>
        </li>-->
      </ul>
      <!-- End #main-nav --> 
     
        
        </div>
      <!-- End #messages -->
    </div>
  </div>

  <!-- End #sidebar -->


  <div id="main-content" style="width:900px" >
    <!-- Main Content Section with everything -->
   
    <!-- Page Head -->
    
    <div style="width:150px; float:left; display:inline;"><asp:TextBox ID="datepicker1" ClientIDMode="Static" runat="server" CssClass="datepicker" placeholder="" style="width:100px; height: 20px;"></asp:TextBox></div>
    
    <div style="width:100px; float:left; display:inline;"><asp:Button class="button" ID="ChooseDate" runat="server" Text="検索" OnClick="ChooseDate_Click"/></div>
    <!-- End .shortcut-buttons-set -->
      
      
    <div class="clear" style="height:30px"></div>
    <!-- End .clear -->
    <div class="content-box">
      <!-- Start Content Box -->
   
      <!-- End .content-box-header -->
      <!-- page1 -->
        <div class="tab-content default-tab" id="page1" runat="server" style="height:700px;width:898px" aria-sort="none">
        
           <div class="content-box-header">
        <h3>出勤時間一覧(月単位)</h3>
      </div>
          <table>  
        <div class="clear"></div>
           <tbody>
               <asp:GridView ID="TimeData" runat="server" AllowPaging="true" PageSize="16" HorizontalAlign="Right" OnPageIndexChanging="TimeData_PageIndexChanging" >
               </asp:GridView>
            </tbody>
          </table>
        </div>
    
  
    <!-- page2 -->
      <div class="tab-content default-tab" id="page2" runat="server" style="height:700px;Width:898px">
           <div class="content-box-header">
        <h3>出勤時間一覧(日単位)</h3>
      </div>
         <table >
        <div class="clear"></div>
           <tbody>
               <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
            </tbody>
         </table>
          
        </div>

        <!-- page3 -->
         <div class="tab-content default-tab" id="page3" runat="server" style="height:700px;Width:898px">
           <div class="content-box-header">
        <h3>残業届出</h3>
      </div>
       <div style="height:100px;width:898px">
       <div style="height:30px;width:898px;margin:0 0 0 20px">
           <table  style="font-size:15px;width:633px; color:black;"  ><tr><td class="auto-style3">区分</td><td class="auto-style1">申請対象日</td><td class="auto-style2">申請時間(h)</td><td>申請理由</td></tr></table>
       </div>
    　 <div style="width:50px; height:20px;float:left; display:inline; margin:15px 0 0 20px">
          <asp:DropDownList ID="DropDownList_Title" runat="server">
              <asp:ListItem>残業</asp:ListItem>
               </asp:DropDownList></div>
       <div style="width:160px; float:left; display:inline; margin:15px 0 0 20px"><asp:TextBox ID="datepicker2" ClientIDMode="Static" runat="server" CssClass="datepicker" placeholder="" style="width:100px; height: 20px;"></asp:TextBox></div>
       <div style="width:155px; float:left; display:inline; margin:15px 0 0 20px"><asp:TextBox ID="ApplyTime" ClientIDMode="Static" runat="server" style="width:100px; height: 20px;"></asp:TextBox></div>
      <div style="width:300px; float:left; display:inline; margin:15px 0 0 20px"><asp:TextBox ID="ApplyReason" ClientIDMode="Static" runat="server" style="width:300px; height: 20px;"></asp:TextBox></div>
       <div style="width:100px; float:left; display:inline;margin:15px 0 0 30px"><asp:Button class="button" ID="ApplyButton" runat="server" Text="申請" OnClick="ApplyButton_Click"/></div>

       </div>
         <table >
        <div class="clear"></div>
        
           <tbody>
               <asp:GridView ID="ApplyData" runat="server"></asp:GridView>
            </tbody>
         </table>
          
        </div>
         <!-- page4 -->
         <div class="tab-content default-tab" id="page4" runat="server" style="height:700px;Width:898px">
           <div class="content-box-header">
        <h3>残業承認</h3>
      </div>
      
        <asp:GridView ID="ApproveData" runat="server"　 AutoGenerateColumns="False" class="content-box-content">
            <Columns>
                <asp:BoundField HeaderText="申請ID" DataField="ApproveID"/>
                <asp:BoundField HeaderText="申請者番号" DataField="ApplyUser" />
                <asp:BoundField HeaderText="区分" DataField="Title"/>
                <asp:BoundField HeaderText="申請対象日" DataField="ApplyTime"/>
                <asp:BoundField HeaderText="残業時間" DataField="AddWorkTime"/>
                <asp:BoundField HeaderText="残業理由" DataField="Reason"/>
                <asp:BoundField HeaderText="状態" DataField="Status"/>
                <asp:TemplateField HeaderText="結果" >
                           <ItemTemplate >
                            <asp:DropDownList ID="Drop_ApproveTitle" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="返事">
                     <EditItemTemplate>
                         <asp:TextBox ID="Reason" runat="server" ></asp:TextBox>
                        </EditItemTemplate>
                </asp:TemplateField>
            
      
               
          
            </Columns>
             </asp:GridView>
           
          
        </div>
         <!-- pageweclome page5-->
         <div class="tab-content default-tab" id="page5" runat="server" style="height:700px;Width:898px;font-size:50pt">
           <div class="content-box-header">
        <h3>こんにちは！</h3>
            
      </div >
             <p >こんにちは！</p>
        </div>
  

    <!-- End Notifications -->
    <div id="footer"> 
      <!-- Remove this notice or replace it with whatever you want -->
      &#169; Copyright 2019 NTMC | Powered by <a href="#">HAOYU QIN</a></div>
    <!-- End #footer -->
  </div>
</div>
    </form>
  <!-- End #main-content -->


</body>
</html>
