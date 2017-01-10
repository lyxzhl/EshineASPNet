<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" href="css/bootstrap.min.css">


<!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
<script src="js/jquery-1.9.1.min.js"></script>

<script src="js/bootstrap.min.js"></script>
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
       
    
         <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                        开始 接口</a>
                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel">
                              <div class="row">
                                  <div class="col-md-4">
                                      <iframe src="testlogin.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                   <div class="col-md-4">
                                      <iframe src="testcustomergetstart.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                   <div class="col-md-4">
                                  <iframe src="testcheckemail.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                  <div class="col-md-4">
                                   <iframe src="testjiankbi.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                  <div class="col-md-4">
                                      <iframe src="textreserveexam.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                  <div class="col-md-4">
                                      
                                  </div>
                                   <div class="col-md-4">
                                     
                                  </div>
                              </div>

                            </div>
                        </div>
                        


             <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree1" aria-expanded="false" aria-controls="collapseThree">
                                       问卷  接口</a>
                                </h4>
                            </div>
                            <div id="collapseThree1" class="panel-collapse collapse" role="tabpanel">
                                <div class="row">
                                       <div class="col-md-4">
                                      <iframe src="testAssessmentAnswer.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                    <div class="col-md-4">
                                      <iframe src="testAssessmentQuestion.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                            <div class="col-md-4">
                                      <iframe src="testQuestionType.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                     <div class="col-md-4">
                                      <iframe src="testQuestionType.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                     <div class="col-md-4">
                                      <iframe src="testQuestionType.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                    </div>
                              </div>
                            </div>






                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                       预约 接口</a>
                                </h4>
                            </div>
                            <div id="collapseThree" class="panel-collapse collapse" role="tabpanel">
                                <div class="row">
                                       <div class="col-md-4">
                                      <iframe src="testwodyuyue.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                    <div class="col-md-4">
                                      <iframe src="testSelectstore.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                    <div class="col-md-4">
                                      <iframe src="testSelectiontime.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                    <div class="col-md-4">
                                      <iframe src="testwodyuyue.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                    </div>
                              </div>
                            </div>
                       
             <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour" aria-expanded="false" aria-controls="collapseThree">
                                       家属 接口</a>
                                </h4>
                            </div>
                            <div id="collapseFour" class="panel-collapse collapse" role="tabpanel">
                                <div class="row">
                                 <div class="col-md-4">
                                      <iframe src="testFamily members.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                 <div class="col-md-4">
                                      <iframe src="testjiashuzil.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                 <div class="col-md-4">
                                      <iframe src="testtijiajiashu.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                    </div>
                            </div>
                        </div>
             <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive" aria-expanded="false" aria-controls="collapseThree">
                                       商城 接口</a>
                                </h4>
                            </div>
                            <div id="collapseFive" class="panel-collapse collapse" role="tabpanel">
                                <div class="row">
                                     <div class="col-md-4">
                                      <iframe src="testproductClass.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                <div class="col-md-4">
                                      <iframe src="testproducts.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                    </div>
                            </div>
                        </div>
             
             <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven" aria-expanded="false" aria-controls="collapseThree">
                                       个人 接口</a>
                                </h4>
                            </div>
                            <div id="collapseSeven" class="panel-collapse collapse" role="tabpanel">
                                 <div class="col-md-4">
                                      <iframe src="textupdatepersonaldetail.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                <div class="col-md-4">
                                      <iframe src="testupdatepassword.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                              
                            </div>
                        </div>
         <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeves" aria-expanded="false" aria-controls="collapseThree">
                                       接口</a>
                                </h4>
                            </div>
                            <div id="collapseSeves" class="panel-collapse collapse" role="tabpanel">
                                 <div class="col-md-4">
                                      <iframe src="texttijiandaoh.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                                <div class="col-md-4">
                                      <iframe src="texttijianwj.aspx" style="width:100%;height:300px;"></iframe>
                                  </div>
                              
                            </div>
                        </div>
                    </div>


    </form>
</body>
</html>
