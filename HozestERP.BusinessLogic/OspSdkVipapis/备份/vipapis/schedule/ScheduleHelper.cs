using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.schedule{
	
	
	
	public class ScheduleHelper : BeanSerializer<Schedule>
	{
		
		public static ScheduleHelper OBJ = new ScheduleHelper();
		
		public static ScheduleHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Schedule structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetSchedule_id(value);
					}
					
					
					
					
					
					if ("schedule_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_name(value);
					}
					
					
					
					
					
					if ("start_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStart_time(value);
					}
					
					
					
					
					
					if ("end_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnd_time(value);
					}
					
					
					
					
					
					if ("index_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIndex_image(value);
					}
					
					
					
					
					
					if ("index_advance_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIndex_advance_image(value);
					}
					
					
					
					
					
					if ("schedule_self_logo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_self_logo(value);
					}
					
					
					
					
					
					if ("logo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLogo(value);
					}
					
					
					
					
					
					if ("agio".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAgio(value);
					}
					
					
					
					
					
					if ("brand_store_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBrand_store_sn(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem1;
								elem1 = iprot.ReadString();
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("brand_name_eng".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem2;
								elem2 = iprot.ReadString();
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBrand_name_eng(value);
					}
					
					
					
					
					
					if ("brand_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem3;
								elem3 = iprot.ReadString();
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBrand_url(value);
					}
					
					
					
					
					
					if ("schedule_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_url(value);
					}
					
					
					
					
					
					if ("schedule_flash".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_flash(value);
					}
					
					
					
					
					
					if ("schedule_mobile_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_mobile_url(value);
					}
					
					
					
					
					
					if ("mobile_image_one".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile_image_one(value);
					}
					
					
					
					
					
					if ("mobile_image_two".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile_image_two(value);
					}
					
					
					
					
					
					if ("mobile_show_from".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile_show_from(value);
					}
					
					
					
					
					
					if ("mobile_show_to".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile_show_to(value);
					}
					
					
					
					
					
					if ("pc_show_from".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPc_show_from(value);
					}
					
					
					
					
					
					if ("pc_show_to".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPc_show_to(value);
					}
					
					
					
					
					
					if ("channels".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem4;
								elem4 = iprot.ReadString();
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetChannels(value);
					}
					
					
					
					
					
					if ("warehouses".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem5;
								elem5 = iprot.ReadString();
								
								value.Add(elem5);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetWarehouses(value);
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
		
		
		public void Write(Schedule structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteI32((int)structs.GetSchedule_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("schedule_id can not be null!");
			}
			
			
			if(structs.GetSchedule_name() != null) {
				
				oprot.WriteFieldBegin("schedule_name");
				oprot.WriteString(structs.GetSchedule_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("schedule_name can not be null!");
			}
			
			
			if(structs.GetStart_time() != null) {
				
				oprot.WriteFieldBegin("start_time");
				oprot.WriteString(structs.GetStart_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("start_time can not be null!");
			}
			
			
			if(structs.GetEnd_time() != null) {
				
				oprot.WriteFieldBegin("end_time");
				oprot.WriteString(structs.GetEnd_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("end_time can not be null!");
			}
			
			
			if(structs.GetIndex_image() != null) {
				
				oprot.WriteFieldBegin("index_image");
				oprot.WriteString(structs.GetIndex_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIndex_advance_image() != null) {
				
				oprot.WriteFieldBegin("index_advance_image");
				oprot.WriteString(structs.GetIndex_advance_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSchedule_self_logo() != null) {
				
				oprot.WriteFieldBegin("schedule_self_logo");
				oprot.WriteString(structs.GetSchedule_self_logo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLogo() != null) {
				
				oprot.WriteFieldBegin("logo");
				oprot.WriteString(structs.GetLogo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAgio() != null) {
				
				oprot.WriteFieldBegin("agio");
				oprot.WriteString(structs.GetAgio());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_store_sn() != null) {
				
				oprot.WriteFieldBegin("brand_store_sn");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetBrand_store_sn()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetBrand_name()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name_eng() != null) {
				
				oprot.WriteFieldBegin("brand_name_eng");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetBrand_name_eng()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_url() != null) {
				
				oprot.WriteFieldBegin("brand_url");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetBrand_url()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSchedule_url() != null) {
				
				oprot.WriteFieldBegin("schedule_url");
				oprot.WriteString(structs.GetSchedule_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSchedule_flash() != null) {
				
				oprot.WriteFieldBegin("schedule_flash");
				oprot.WriteString(structs.GetSchedule_flash());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSchedule_mobile_url() != null) {
				
				oprot.WriteFieldBegin("schedule_mobile_url");
				oprot.WriteString(structs.GetSchedule_mobile_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile_image_one() != null) {
				
				oprot.WriteFieldBegin("mobile_image_one");
				oprot.WriteString(structs.GetMobile_image_one());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile_image_two() != null) {
				
				oprot.WriteFieldBegin("mobile_image_two");
				oprot.WriteString(structs.GetMobile_image_two());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile_show_from() != null) {
				
				oprot.WriteFieldBegin("mobile_show_from");
				oprot.WriteString(structs.GetMobile_show_from());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("mobile_show_from can not be null!");
			}
			
			
			if(structs.GetMobile_show_to() != null) {
				
				oprot.WriteFieldBegin("mobile_show_to");
				oprot.WriteString(structs.GetMobile_show_to());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("mobile_show_to can not be null!");
			}
			
			
			if(structs.GetPc_show_from() != null) {
				
				oprot.WriteFieldBegin("pc_show_from");
				oprot.WriteString(structs.GetPc_show_from());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("pc_show_from can not be null!");
			}
			
			
			if(structs.GetPc_show_to() != null) {
				
				oprot.WriteFieldBegin("pc_show_to");
				oprot.WriteString(structs.GetPc_show_to());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("pc_show_to can not be null!");
			}
			
			
			if(structs.GetChannels() != null) {
				
				oprot.WriteFieldBegin("channels");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetChannels()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouses() != null) {
				
				oprot.WriteFieldBegin("warehouses");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetWarehouses()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Schedule bean){
			
			
		}
		
	}
	
}