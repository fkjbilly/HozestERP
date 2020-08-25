using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class HtProductHelper : TBeanSerializer<HtProduct>
	{
		
		public static HtProductHelper OBJ = new HtProductHelper();
		
		public static HtProductHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtProduct structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUrl(value);
					}
					
					
					
					
					
					if ("long_title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLong_title(value);
					}
					
					
					
					
					
					if ("short_title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShort_title(value);
					}
					
					
					
					
					
					if ("identify".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIdentify(value);
					}
					
					
					
					
					
					if ("wapurl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWapurl(value);
					}
					
					
					
					
					
					if ("img_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImg_url(value);
					}
					
					
					
					
					
					if ("big_img_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBig_img_url(value);
					}
					
					
					
					
					
					if ("long_img_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLong_img_url(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("reference_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetReference_price(value);
					}
					
					
					
					
					
					if ("former_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetFormer_price(value);
					}
					
					
					
					
					
					if ("discount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDiscount(value);
					}
					
					
					
					
					
					if ("deal_sale".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetDeal_sale(value);
					}
					
					
					
					
					
					if ("type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetType(value);
					}
					
					
					
					
					
					if ("country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry(value);
					}
					
					
					
					
					
					if ("country_logo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry_logo(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("site".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSite(value);
					}
					
					
					
					
					
					if ("site_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSite_url(value);
					}
					
					
					
					
					
					if ("tagid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTagid(value);
					}
					
					
					
					
					
					if ("tag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTag(value);
					}
					
					
					
					
					
					if ("categoryid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCategoryid(value);
					}
					
					
					
					
					
					if ("category".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCategory(value);
					}
					
					
					
					
					
					if ("post".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPost(value);
					}
					
					
					
					
					
					if ("description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDescription(value);
					}
					
					
					
					
					
					if ("starttime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetStarttime(value);
					}
					
					
					
					
					
					if ("endtime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetEndtime(value);
					}
					
					
					
					
					
					if ("is_new".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIs_new(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("friendly_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFriendly_name(value);
					}
					
					
					
					
					
					if ("logo_small".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLogo_small(value);
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
		
		
		public void Write(HtProduct structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUrl() != null) {
				
				oprot.WriteFieldBegin("url");
				oprot.WriteString(structs.GetUrl());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("url can not be null!");
			}
			
			
			if(structs.GetLong_title() != null) {
				
				oprot.WriteFieldBegin("long_title");
				oprot.WriteString(structs.GetLong_title());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("long_title can not be null!");
			}
			
			
			if(structs.GetShort_title() != null) {
				
				oprot.WriteFieldBegin("short_title");
				oprot.WriteString(structs.GetShort_title());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("short_title can not be null!");
			}
			
			
			if(structs.GetIdentify() != null) {
				
				oprot.WriteFieldBegin("identify");
				oprot.WriteString(structs.GetIdentify());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("identify can not be null!");
			}
			
			
			if(structs.GetWapurl() != null) {
				
				oprot.WriteFieldBegin("wapurl");
				oprot.WriteString(structs.GetWapurl());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("wapurl can not be null!");
			}
			
			
			if(structs.GetImg_url() != null) {
				
				oprot.WriteFieldBegin("img_url");
				oprot.WriteString(structs.GetImg_url());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("img_url can not be null!");
			}
			
			
			if(structs.GetBig_img_url() != null) {
				
				oprot.WriteFieldBegin("big_img_url");
				oprot.WriteString(structs.GetBig_img_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLong_img_url() != null) {
				
				oprot.WriteFieldBegin("long_img_url");
				oprot.WriteString(structs.GetLong_img_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteDouble((double)structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("price can not be null!");
			}
			
			
			if(structs.GetReference_price() != null) {
				
				oprot.WriteFieldBegin("reference_price");
				oprot.WriteDouble((double)structs.GetReference_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("reference_price can not be null!");
			}
			
			
			if(structs.GetFormer_price() != null) {
				
				oprot.WriteFieldBegin("former_price");
				oprot.WriteDouble((double)structs.GetFormer_price());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("former_price can not be null!");
			}
			
			
			if(structs.GetDiscount() != null) {
				
				oprot.WriteFieldBegin("discount");
				oprot.WriteString(structs.GetDiscount());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("discount can not be null!");
			}
			
			
			if(structs.GetDeal_sale() != null) {
				
				oprot.WriteFieldBegin("deal_sale");
				oprot.WriteI64((long)structs.GetDeal_sale()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("deal_sale can not be null!");
			}
			
			
			if(structs.GetType() != null) {
				
				oprot.WriteFieldBegin("type");
				oprot.WriteString(structs.GetType());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("type can not be null!");
			}
			
			
			if(structs.GetCountry() != null) {
				
				oprot.WriteFieldBegin("country");
				oprot.WriteString(structs.GetCountry());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("country can not be null!");
			}
			
			
			if(structs.GetCountry_logo() != null) {
				
				oprot.WriteFieldBegin("country_logo");
				oprot.WriteString(structs.GetCountry_logo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("country_logo can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSite() != null) {
				
				oprot.WriteFieldBegin("site");
				oprot.WriteString(structs.GetSite());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("site can not be null!");
			}
			
			
			if(structs.GetSite_url() != null) {
				
				oprot.WriteFieldBegin("site_url");
				oprot.WriteString(structs.GetSite_url());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("site_url can not be null!");
			}
			
			
			if(structs.GetTagid() != null) {
				
				oprot.WriteFieldBegin("tagid");
				oprot.WriteString(structs.GetTagid());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("tagid can not be null!");
			}
			
			
			if(structs.GetTag() != null) {
				
				oprot.WriteFieldBegin("tag");
				oprot.WriteString(structs.GetTag());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("tag can not be null!");
			}
			
			
			if(structs.GetCategoryid() != null) {
				
				oprot.WriteFieldBegin("categoryid");
				oprot.WriteString(structs.GetCategoryid());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("categoryid can not be null!");
			}
			
			
			if(structs.GetCategory() != null) {
				
				oprot.WriteFieldBegin("category");
				oprot.WriteString(structs.GetCategory());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("category can not be null!");
			}
			
			
			if(structs.GetPost() != null) {
				
				oprot.WriteFieldBegin("post");
				oprot.WriteString(structs.GetPost());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("post can not be null!");
			}
			
			
			if(structs.GetDescription() != null) {
				
				oprot.WriteFieldBegin("description");
				oprot.WriteString(structs.GetDescription());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStarttime() != null) {
				
				oprot.WriteFieldBegin("starttime");
				oprot.WriteI64((long)structs.GetStarttime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEndtime() != null) {
				
				oprot.WriteFieldBegin("endtime");
				oprot.WriteI64((long)structs.GetEndtime()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("endtime can not be null!");
			}
			
			
			if(structs.GetIs_new() != null) {
				
				oprot.WriteFieldBegin("is_new");
				oprot.WriteString(structs.GetIs_new());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_new can not be null!");
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteString(structs.GetBrand_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("brand_id can not be null!");
			}
			
			
			if(structs.GetFriendly_name() != null) {
				
				oprot.WriteFieldBegin("friendly_name");
				oprot.WriteString(structs.GetFriendly_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("friendly_name can not be null!");
			}
			
			
			if(structs.GetLogo_small() != null) {
				
				oprot.WriteFieldBegin("logo_small");
				oprot.WriteString(structs.GetLogo_small());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("logo_small can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtProduct bean){
			
			
		}
		
	}
	
}