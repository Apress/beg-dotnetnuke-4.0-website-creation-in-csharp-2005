<%@ Control Language="C#" Inherits="YourCompany.Modules.TimePunch.EditTimePunch"
  CodeFile="EditTimePunch.ascx.cs" AutoEventWireup="true" %>
<%@ Register TagPrefix="dnn" TagName="Label" 
                             Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" 
                             Src="~/controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Audit" 
                             Src="~/controls/ModuleAuditControl.ascx" %>
<table width="650" cellspacing="0" cellpadding="0" border="0" summary="Edit Table">
  <tr valign="top">
    <td class="SubHead" width="125" style="height: 268px">
      <dnn:Label ID="lblContent" runat="server" ControlName="lblContent" 
                                                Suffix=":"></dnn:Label>
    </td>
    <td style="height: 268px">
      <dnn:TextEditor ID="txtContent" runat="server" Height="200" Width="500" />
      <asp:RequiredFieldValidator ID="valContent" 
        resourcekey="valContent.ErrorMessage"
        ControlToValidate="txtContent" CssClass="NormalRed" Display="Dynamic" 
        ErrorMessage="<br>Content is required"
        runat="server" />
        <font color=red size=5 ><b>There is no content to edit.</b></font>
    </td>
  </tr>
</table>
<p>
  <asp:LinkButton CssClass="CommandButton" ID="cmdUpdate" OnClick="cmdUpdate_Click"
    resourcekey="cmdUpdate" runat="server" BorderStyle="none" Text="Update">
  </asp:LinkButton>&nbsp;
  <asp:LinkButton CssClass="CommandButton" ID="cmdCancel" OnClick="cmdCancel_Click"
    resourcekey="cmdCancel" runat="server" BorderStyle="none" Text="Cancel" 
    CausesValidation="False">
  </asp:LinkButton>&nbsp;
  <asp:LinkButton CssClass="CommandButton" ID="cmdDelete" OnClick="cmdDelete_Click"
    resourcekey="cmdDelete" runat="server" BorderStyle="none" Text="Delete" 
    CausesValidation="False">
  </asp:LinkButton>&nbsp;
</p>
<dnn:Audit ID="ctlAudit" runat="server" />
