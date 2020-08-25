using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtSaleOrderChbResultModelHelper : TBeanSerializer<HtSaleOrderChbResultModel>
	{
		
		public static HtSaleOrderChbResultModelHelper OBJ = new HtSaleOrderChbResultModelHelper();
		
		public static HtSaleOrderChbResultModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtSaleOrderChbResultModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("saleType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSaleType(value);
					}
					
					
					
					
					
					if ("isTmsProvideTransportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsTmsProvideTransportNo(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("transportDay".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportDay(value);
					}
					
					
					
					
					
					if ("batchNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNumber(value);
					}
					
					
					
					
					
					if ("ladingBillNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLadingBillNumber(value);
					}
					
					
					
					
					
					if ("subLadingBillNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSubLadingBillNumber(value);
					}
					
					
					
					
					
					if ("brandId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetBrandId(value);
					}
					
					
					
					
					
					if ("buyer".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBuyer(value);
					}
					
					
					
					
					
					if ("address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("district".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDistrict(value);
					}
					
					
					
					
					
					if ("street".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStreet(value);
					}
					
					
					
					
					
					if ("buyerIdcard".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBuyerIdcard(value);
					}
					
					
					
					
					
					if ("tel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTel(value);
					}
					
					
					
					
					
					if ("mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile(value);
					}
					
					
					
					
					
					if ("totalMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTotalMoney(value);
					}
					
					
					
					
					
					if ("payMount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetPayMount(value);
					}
					
					
					
					
					
					if ("favourableMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetFavourableMoney(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetCarriage(value);
					}
					
					
					
					
					
					if ("customCarriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetCustomCarriage(value);
					}
					
					
					
					
					
					if ("taxFee".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTaxFee(value);
					}
					
					
					
					
					
					if ("payMoneyType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayMoneyType(value);
					}
					
					
					
					
					
					if ("tradeNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTradeNumber(value);
					}
					
					
					
					
					
					if ("payTypeNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayTypeNumber(value);
					}
					
					
					
					
					
					if ("enterpriseCertCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnterpriseCertCode(value);
					}
					
					
					
					
					
					if ("carriersName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriersName(value);
					}
					
					
					
					
					
					if ("carrierPointCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrierPointCode(value);
					}
					
					
					
					
					
					if ("carrierPointName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrierPointName(value);
					}
					
					
					
					
					
					if ("transportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportNo(value);
					}
					
					
					
					
					
					if ("originCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOriginCode(value);
					}
					
					
					
					
					
					if ("destinationCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDestinationCode(value);
					}
					
					
					
					
					
					if ("templateCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTemplateCode(value);
					}
					
					
					
					
					
					if ("pickCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPickCode(value);
					}
					
					
					
					
					
					if ("custCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustCode(value);
					}
					
					
					
					
					
					if ("customsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsCode(value);
					}
					
					
					
					
					
					if ("chinaFreightForwarding".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetChinaFreightForwarding(value);
					}
					
					
					
					
					
					if ("globalFreightForwarding".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGlobalFreightForwarding(value);
					}
					
					
					
					
					
					if ("customsClearanceMode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsClearanceMode(value);
					}
					
					
					
					
					
					if ("updateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUpdateTime(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("isPackage".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetIsPackage(value);
					}
					
					
					
					
					
					if ("declareType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetDeclareType(value);
					}
					
					
					
					
					
					if ("buyerIdtype".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBuyerIdtype(value);
					}
					
					
					
					
					
					if ("payerName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayerName(value);
					}
					
					
					
					
					
					if ("payerIdtype".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetPayerIdtype(value);
					}
					
					
					
					
					
					if ("payerIdnumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayerIdnumber(value);
					}
					
					
					
					
					
					if ("payerTelephone".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayerTelephone(value);
					}
					
					
					
					
					
					if ("logisticsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLogisticsCode(value);
					}
					
					
					
					
					
					if ("logisticsName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLogisticsName(value);
					}
					
					
					
					
					
					if ("brandName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandName(value);
					}
					
					
					
					
					
					if ("HtSaleOrderInfoVopModelList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.orderservice.service.HtSaleOrderInfoChbModel> value;
						
						value = new List<com.vip.haitao.orderservice.service.HtSaleOrderInfoChbModel>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.HtSaleOrderInfoChbModel elem1;
								
								elem1 = new com.vip.haitao.orderservice.service.HtSaleOrderInfoChbModel();
								com.vip.haitao.orderservice.service.HtSaleOrderInfoChbModelHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetHtSaleOrderInfoVopModelList(value);
					}
					
					
					
					
					
					if ("channel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetChannel(value);
					}
					
					
					
					
					
					if ("userDef1".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef1(value);
					}
					
					
					
					
					
					if ("userDef2".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef2(value);
					}
					
					
					
					
					
					if ("userDef3".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef3(value);
					}
					
					
					
					
					
					if ("userDef4".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef4(value);
					}
					
					
					
					
					
					if ("userDef5".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserDef5(value);
					}
					
					
					
					
					
					if ("userDef6".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserDef6(value);
					}
					
					
					
					
					
					if ("userDef7".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef7(value);
					}
					
					
					
					
					
					if ("userDef8".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef8(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(HtSaleOrderChbResultModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteString(structs.GetOrderId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleType() != null) {
				
				oprot.WriteFieldBegin("saleType");
				oprot.WriteString(structs.GetSaleType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsTmsProvideTransportNo() != null) {
				
				oprot.WriteFieldBegin("isTmsProvideTransportNo");
				oprot.WriteI32((int)structs.GetIsTmsProvideTransportNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteString(structs.GetCreateTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportDay() != null) {
				
				oprot.WriteFieldBegin("transportDay");
				oprot.WriteString(structs.GetTransportDay());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBatchNumber() != null) {
				
				oprot.WriteFieldBegin("batchNumber");
				oprot.WriteString(structs.GetBatchNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLadingBillNumber() != null) {
				
				oprot.WriteFieldBegin("ladingBillNumber");
				oprot.WriteString(structs.GetLadingBillNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubLadingBillNumber() != null) {
				
				oprot.WriteFieldBegin("subLadingBillNumber");
				oprot.WriteString(structs.GetSubLadingBillNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandId() != null) {
				
				oprot.WriteFieldBegin("brandId");
				oprot.WriteI64((long)structs.GetBrandId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBuyer() != null) {
				
				oprot.WriteFieldBegin("buyer");
				oprot.WriteString(structs.GetBuyer());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDistrict() != null) {
				
				oprot.WriteFieldBegin("district");
				oprot.WriteString(structs.GetDistrict());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStreet() != null) {
				
				oprot.WriteFieldBegin("street");
				oprot.WriteString(structs.GetStreet());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBuyerIdcard() != null) {
				
				oprot.WriteFieldBegin("buyerIdcard");
				oprot.WriteString(structs.GetBuyerIdcard());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTel() != null) {
				
				oprot.WriteFieldBegin("tel");
				oprot.WriteString(structs.GetTel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile() != null) {
				
				oprot.WriteFieldBegin("mobile");
				oprot.WriteString(structs.GetMobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalMoney() != null) {
				
				oprot.WriteFieldBegin("totalMoney");
				oprot.WriteDouble((double)structs.GetTotalMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayMount() != null) {
				
				oprot.WriteFieldBegin("payMount");
				oprot.WriteDouble((double)structs.GetPayMount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFavourableMoney() != null) {
				
				oprot.WriteFieldBegin("favourableMoney");
				oprot.WriteDouble((double)structs.GetFavourableMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteDouble((double)structs.GetCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomCarriage() != null) {
				
				oprot.WriteFieldBegin("customCarriage");
				oprot.WriteDouble((double)structs.GetCustomCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTaxFee() != null) {
				
				oprot.WriteFieldBegin("taxFee");
				oprot.WriteDouble((double)structs.GetTaxFee());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayMoneyType() != null) {
				
				oprot.WriteFieldBegin("payMoneyType");
				oprot.WriteString(structs.GetPayMoneyType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTradeNumber() != null) {
				
				oprot.WriteFieldBegin("tradeNumber");
				oprot.WriteString(structs.GetTradeNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayTypeNumber() != null) {
				
				oprot.WriteFieldBegin("payTypeNumber");
				oprot.WriteString(structs.GetPayTypeNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnterpriseCertCode() != null) {
				
				oprot.WriteFieldBegin("enterpriseCertCode");
				oprot.WriteString(structs.GetEnterpriseCertCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriersName() != null) {
				
				oprot.WriteFieldBegin("carriersName");
				oprot.WriteString(structs.GetCarriersName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrierPointCode() != null) {
				
				oprot.WriteFieldBegin("carrierPointCode");
				oprot.WriteString(structs.GetCarrierPointCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrierPointName() != null) {
				
				oprot.WriteFieldBegin("carrierPointName");
				oprot.WriteString(structs.GetCarrierPointName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportNo() != null) {
				
				oprot.WriteFieldBegin("transportNo");
				oprot.WriteString(structs.GetTransportNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOriginCode() != null) {
				
				oprot.WriteFieldBegin("originCode");
				oprot.WriteString(structs.GetOriginCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDestinationCode() != null) {
				
				oprot.WriteFieldBegin("destinationCode");
				oprot.WriteString(structs.GetDestinationCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTemplateCode() != null) {
				
				oprot.WriteFieldBegin("templateCode");
				oprot.WriteString(structs.GetTemplateCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPickCode() != null) {
				
				oprot.WriteFieldBegin("pickCode");
				oprot.WriteString(structs.GetPickCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustCode() != null) {
				
				oprot.WriteFieldBegin("custCode");
				oprot.WriteString(structs.GetCustCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomsCode() != null) {
				
				oprot.WriteFieldBegin("customsCode");
				oprot.WriteString(structs.GetCustomsCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetChinaFreightForwarding() != null) {
				
				oprot.WriteFieldBegin("chinaFreightForwarding");
				oprot.WriteString(structs.GetChinaFreightForwarding());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGlobalFreightForwarding() != null) {
				
				oprot.WriteFieldBegin("globalFreightForwarding");
				oprot.WriteString(structs.GetGlobalFreightForwarding());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomsClearanceMode() != null) {
				
				oprot.WriteFieldBegin("customsClearanceMode");
				oprot.WriteString(structs.GetCustomsClearanceMode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTime() != null) {
				
				oprot.WriteFieldBegin("updateTime");
				oprot.WriteString(structs.GetUpdateTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteI32((int)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status can not be null!");
			}
			
			
			if(structs.GetIsPackage() != null) {
				
				oprot.WriteFieldBegin("isPackage");
				oprot.WriteI32((int)structs.GetIsPackage()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("isPackage can not be null!");
			}
			
			
			if(structs.GetDeclareType() != null) {
				
				oprot.WriteFieldBegin("declareType");
				oprot.WriteI32((int)structs.GetDeclareType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("declareType can not be null!");
			}
			
			
			if(structs.GetBuyerIdtype() != null) {
				
				oprot.WriteFieldBegin("buyerIdtype");
				oprot.WriteI32((int)structs.GetBuyerIdtype()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("buyerIdtype can not be null!");
			}
			
			
			if(structs.GetPayerName() != null) {
				
				oprot.WriteFieldBegin("payerName");
				oprot.WriteString(structs.GetPayerName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayerIdtype() != null) {
				
				oprot.WriteFieldBegin("payerIdtype");
				oprot.WriteI32((int)structs.GetPayerIdtype()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("payerIdtype can not be null!");
			}
			
			
			if(structs.GetPayerIdnumber() != null) {
				
				oprot.WriteFieldBegin("payerIdnumber");
				oprot.WriteString(structs.GetPayerIdnumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayerTelephone() != null) {
				
				oprot.WriteFieldBegin("payerTelephone");
				oprot.WriteString(structs.GetPayerTelephone());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLogisticsCode() != null) {
				
				oprot.WriteFieldBegin("logisticsCode");
				oprot.WriteString(structs.GetLogisticsCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLogisticsName() != null) {
				
				oprot.WriteFieldBegin("logisticsName");
				oprot.WriteString(structs.GetLogisticsName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandName() != null) {
				
				oprot.WriteFieldBegin("brandName");
				oprot.WriteString(structs.GetBrandName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHtSaleOrderInfoVopModelList() != null) {
				
				oprot.WriteFieldBegin("HtSaleOrderInfoVopModelList");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.orderservice.service.HtSaleOrderInfoChbModel _item0 in structs.GetHtSaleOrderInfoVopModelList()){
					
					
					com.vip.haitao.orderservice.service.HtSaleOrderInfoChbModelHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetChannel() != null) {
				
				oprot.WriteFieldBegin("channel");
				oprot.WriteString(structs.GetChannel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef1() != null) {
				
				oprot.WriteFieldBegin("userDef1");
				oprot.WriteString(structs.GetUserDef1());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef2() != null) {
				
				oprot.WriteFieldBegin("userDef2");
				oprot.WriteString(structs.GetUserDef2());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef3() != null) {
				
				oprot.WriteFieldBegin("userDef3");
				oprot.WriteString(structs.GetUserDef3());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef4() != null) {
				
				oprot.WriteFieldBegin("userDef4");
				oprot.WriteString(structs.GetUserDef4());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef5() != null) {
				
				oprot.WriteFieldBegin("userDef5");
				oprot.WriteI64((long)structs.GetUserDef5()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef6() != null) {
				
				oprot.WriteFieldBegin("userDef6");
				oprot.WriteI64((long)structs.GetUserDef6()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef7() != null) {
				
				oprot.WriteFieldBegin("userDef7");
				oprot.WriteString(structs.GetUserDef7());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef8() != null) {
				
				oprot.WriteFieldBegin("userDef8");
				oprot.WriteString(structs.GetUserDef8());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtSaleOrderChbResultModel bean){
			
			
		}
		
	}
	
}