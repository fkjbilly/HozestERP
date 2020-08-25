using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class GetPoFinancialDetailResponseHelper : TBeanSerializer<GetPoFinancialDetailResponse>
	{
		
		public static GetPoFinancialDetailResponseHelper OBJ = new GetPoFinancialDetailResponseHelper();
		
		public static GetPoFinancialDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPoFinancialDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("has_next".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetHas_next(value);
					}
					
					
					
					
					
					if ("po_financial_details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.finance.PoFinancialDetail> value;
						
						value = new List<vipapis.finance.PoFinancialDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.finance.PoFinancialDetail elem0;
								
								elem0 = new vipapis.finance.PoFinancialDetail();
								vipapis.finance.PoFinancialDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPo_financial_details(value);
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
		
		
		public void Write(GetPoFinancialDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI64((long)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHas_next() != null) {
				
				oprot.WriteFieldBegin("has_next");
				oprot.WriteBool((bool)structs.GetHas_next());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("has_next can not be null!");
			}
			
			
			if(structs.GetPo_financial_details() != null) {
				
				oprot.WriteFieldBegin("po_financial_details");
				
				oprot.WriteListBegin();
				foreach(vipapis.finance.PoFinancialDetail _item0 in structs.GetPo_financial_details()){
					
					
					vipapis.finance.PoFinancialDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPoFinancialDetailResponse bean){
			
			
		}
		
	}
	
}