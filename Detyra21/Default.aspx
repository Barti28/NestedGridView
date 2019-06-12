<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Detyra21._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <h1>Biblioteka e qytetit</h1>
    
    <h2 aria-atomic="False"> Të dhënat e lexuesit dhe të librit</h2>
    <br />
    <br />

   <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="LexuesiID"
            OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" EmptyDataText="Nuk ka te dhena" >
            <RowStyle BackColor="Gainsboro" />
            <AlternatingRowStyle BackColor="White" />
            <HeaderStyle BackColor="#0083C1" ForeColor="White"/>
            <FooterStyle BackColor="White" />
            <Columns>
                
                <asp:TemplateField HeaderText="#" ItemStyle-Width="20" >
                    <ItemTemplate>
                        <a href="JavaScript:divexpandcollapse('div<%# Eval("LexuesiID") %>');">
                            <img id="imgdiv<%# Eval("LexuesiID") %>" width="9px" border="0" src="./Imazhe/plus.png"  />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Emri" SortExpression="Emri" ItemStyle-Width="150">
                    <ItemTemplate><%# Eval("Emri") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmri" Text='<%# Eval("Emri") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mbiemri" SortExpression="Mbiemri" ItemStyle-Width="150">
                    <ItemTemplate><%# Eval("Mbiemri") %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMbiemri" Text='<%# Eval("Mbiemri") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Celulari" SortExpression="Celulari" ItemStyle-Width="150">
                    <ItemTemplate><%# Eval("Celulari")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCelulari" Text='<%# Eval("Celulari") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Emaili" SortExpression="Emaili" ItemStyle-Width="150">
                    <ItemTemplate><%# Eval("Emaili")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmaili" Text='<%# Eval("Emaili") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data e Dorezimit" SortExpression="Data e Dorezimit" ItemStyle-Width="150">
                    <ItemTemplate><%# Eval("[Data e Dorezimit]")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDataDorezimit" Text='<%# Eval("[Data e Dorezimit]") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txtDataDorezimitFooter" ></asp:TextBox>
                    </FooterTemplate>
		       </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <div id="div<%# Eval("LexuesiID")%>" style="display:none;position:relative;left:15px; overflow:auto;">
                                    <asp:GridView ID="gvLibri" runat="server" AutoGenerateColumns="false" DataKeyNames="LiberID"
                                        
                                         OnRowEditing="gvLibri_RowEditing" OnRowCancelingEdit="gvLibri_RowCancelingEdit"
                                        OnRowUpdating="gvLibri_RowUpdating" OnRowDeleting="gvLibri_RowDeleting" EmptyDataText="Nuk ka te dhena" >
                                        <RowStyle BackColor="Gainsboro" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#0083C1" ForeColor="White"/>
                                        <FooterStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Titulli i Librit" SortExpression="Titulli" ItemStyle-Width="150" >
                                                <ItemTemplate><%# Eval("[Titulli i Librit]") %></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTitulli" Text='<%# Eval("[Titulli i Librit]") %>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox runat="server" ID="txtTitulliFooter" ></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Autori" SortExpression="Autori" ItemStyle-Width="150" >
                                                <ItemTemplate><%# Eval("[Autori]") %></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtAutori" Text='<%# Eval("[Autori]") %>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox runat="server" ID="txtAutoritFooter" ></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lloji" SortExpression="Lloji" ItemStyle-Width="150" >
                                                <ItemTemplate><%# Eval("[Lloji]") %></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtLloji" Text='<%# Eval("[Lloji]") %>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox runat="server" ID="txtLlojiFooter" ></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nr i Faqeve" SortExpression="Nr i Faqeve" ItemStyle-Width="150" >
                                                <ItemTemplate><%# Eval("[Nr i faqeve]") %></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtNrFaqeve" Text='<%# Eval("[Nr i faqeve]") %>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox runat="server" ID="txtNrFaqeveFooter" ></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Viti i Botimit" SortExpression="Viti i Botimit" ItemStyle-Width="150" >
                                                <ItemTemplate><%# Eval("[Viti i Botimit]") %></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtVitiBotimit" Text='<%# Eval("[Viti i Botimit]") %>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox runat="server" ID="txtVitiBotimitFooter" ></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gjendja e Librit" SortExpression="Gjendja e Librit" ItemStyle-Width="150" >
                                                <ItemTemplate><%# Eval("[Gjendja e Librit]") %></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtGjendjaLibrit" Text='<%# Eval("[Gjendja e Librit]") %>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox runat="server" ID="txtGjendjELibritFooter" ></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN" ItemStyle-Width="150" >
                                                <ItemTemplate><%# Eval("[ISBN  e librit]") %></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtISBN" Text='<%# Eval("[ISBN  e librit]") %>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox runat="server" ID="txtISBNFooter" ></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Data e marre" SortExpression="Data e marre" ItemStyle-Width="150" >
                                                <ItemTemplate><%# Eval("[Data e marre]") %></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtDataEMarre" Text='<%# Eval("[Data e marre]") %>' runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox runat="server" ID="txtDataEMarreFooter" ></asp:TextBox>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" />


                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
			</Columns>
        </asp:GridView>


       <br />
       <br />
       <h2 aria-atomic="False"> Shtoni lexues të rinj</h2>
       <br>
       <table border="1" style="border-collapse: collapse;">
           <tr>
              
               <td style="width: 150px">
                   Emri:<br />
                   <asp:TextBox runat="server" ID="txtEmri1" Width="140" />
               </td>
               <td style="width: 150px">
                   Mbiemri:<br />
                   <asp:TextBox runat="server" ID="txtMbiemri1" Width="140" />
               </td>
               <td style="width: 150px">
                   Celulari:<br />
                   <asp:TextBox runat="server" ID="txtCelulari1" Width="140" />
               </td>
               <td style="width: 150px">
                   Emaili:<br />
                   <asp:TextBox runat="server" ID="txtEmaili1" Width="140" />
               </td>
               <td style="width: 150px">
                   Data e Dorezimit:<br />
                   <asp:TextBox runat="server" ID="txtDataDorezimit1" Width="140" />
               </td>
               <td style="width: 100px">
                   <asp:Button ID="btnShto" runat="server" Text="Shto" OnClick="btnShto_Click" />
               </td>
               
           </tr>
       </table>
       </br>
        </br>
       <h2 aria-atomic="False"> Shtoni libra të tjerë për lexuesit e regjistruar</h2>
        <br>
       <table border="1" style="border-collapse: collapse;">
           <tr>
               <td style="width: 150px">
                   Titulli i Librit:<br />
                   <asp:TextBox runat="server" ID="txttitulli1" Width="120" />
               </td>
               <td style="width: 150px">
                   Lexuesi:<br />
                   <asp:DropDownList ID="DbListLexuesiID" runat="server" AutoPostBack="true"  DataTextField="Emri" DataValueField="LexuesiID"></asp:DropDownList>
               </td>
               <td style="width: 150px">
                   Autori:<br />
                   <asp:TextBox runat="server" ID="txtautori1" Width="120" />
               </td>
               <td style="width: 150px">
                   Lloji:<br />
                   <asp:TextBox runat="server" ID="txtlloji1" Width="120" />
               </td>
               <td style="width: 150px">
                   Nr. i faqeve:<br />
                   <asp:TextBox runat="server" ID="txtnumri1" Width="120" />
               </td>
               <td style="width: 150px">
                   Viti i botimit:<br />
                   <asp:TextBox runat="server" ID="txtviti1" Width="120" />
               </td>
                 <td style="width: 150px">
                   Gjendja e Librit:<br />
                   <asp:TextBox runat="server" ID="txtgjendja1" Width="120" />
               </td>
                 <td style="width: 150px">
                   ISBN  e librit:<br />
                   <asp:TextBox runat="server" ID="txtisbn1" Width="120" />
               </td>  <td style="width: 150px">
                   Data e marre:<br />
                   <asp:TextBox runat="server" ID="txtdata1" Width="120" />
               </td>

               <td style="width: 100px">
                   <asp:Button ID="btnShto1" runat="server" Text="Shto" OnClick="btn1Shto_Click" />
               </td>
               </tr>
           </table>
       </br>
       <br />
          <br />
          <br />
          <br />
          <br />
          <br />
          <br />
          <br />
    
       </div>
</asp:Content>
