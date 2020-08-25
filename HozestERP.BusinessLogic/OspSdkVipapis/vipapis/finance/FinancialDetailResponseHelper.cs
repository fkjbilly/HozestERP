using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class FinancialDetailResponseHelper : TBeanSerializer<FinancialDetailResponse>
	{
		
		public static FinancialDetailResponseHelper OBJ = new FinancialDetailResponseHelper();
		
		public static FinancialDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FinancialDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.finance.FinancialDetail> value;
						
						value = new List<vipapis.finance.FinancialDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.finance.FinancialDetail elem1;
								
								elem1 = new vipapis.finance.FinancialDetail();
								vipapis.finance.FinancialDetailHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDetails(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(FinancialDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDetails() != null) {
				
				oprot.WriteFieldBegin("details");
				
				oprot.WriteListBegin();
				foreach(vipapis.finance.FinancialDetail _item0 in structs.GetDetails()){
					
					
					vipapis.finance.FinancialDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(FinancialDetailResponse bean){
			
			
		}
		
	}
	
}