using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class TransactionHelper : TBeanSerializer<Transaction>
	{
		
		public static TransactionHelper OBJ = new TransactionHelper();
		
		public static TransactionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Transaction structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("transfer_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransfer_sn(value);
					}
					
					
					
					
					
					if ("out_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOut_time(value);
					}
					
					
					
					
					
					if ("total_cases".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal_cases(value);
					}
					
					
					
					
					
					if ("total_skus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal_skus(value);
					}
					
					
					
					
					
					if ("total_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal_num(value);
					}
					
					
					
					
					
					if ("product_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.TransactionProduct> value;
						
						value = new List<vipapis.overseas.TransactionProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.TransactionProduct elem1;
								
								elem1 = new vipapis.overseas.TransactionProduct();
								vipapis.overseas.TransactionProductHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProduct_list(value);
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
		
		
		public void Write(Transaction structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetTransfer_sn() != null) {
				
				oprot.WriteFieldBegin("transfer_sn");
				oprot.WriteString(structs.GetTransfer_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transfer_sn can not be null!");
			}
			
			
			if(structs.GetOut_time() != null) {
				
				oprot.WriteFieldBegin("out_time");
				oprot.WriteString(structs.GetOut_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("out_time can not be null!");
			}
			
			
			if(structs.GetTotal_cases() != null) {
				
				oprot.WriteFieldBegin("total_cases");
				oprot.WriteI32((int)structs.GetTotal_cases()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_cases can not be null!");
			}
			
			
			if(structs.GetTotal_skus() != null) {
				
				oprot.WriteFieldBegin("total_skus");
				oprot.WriteI32((int)structs.GetTotal_skus()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_skus can not be null!");
			}
			
			
			if(structs.GetTotal_num() != null) {
				
				oprot.WriteFieldBegin("total_num");
				oprot.WriteI32((int)structs.GetTotal_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_num can not be null!");
			}
			
			
			if(structs.GetProduct_list() != null) {
				
				oprot.WriteFieldBegin("product_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.TransactionProduct _item0 in structs.GetProduct_list()){
					
					
					vipapis.overseas.TransactionProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Transaction bean){
			
			
		}
		
	}
	
}