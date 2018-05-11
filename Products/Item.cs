namespace Products

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ihdnum { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string name_cleaned { get; set; }

        [StringLength(255)]
        public string name_display { get; set; }

        [StringLength(100)]
        public string brand { get; set; }

        [StringLength(100)]
        public string brandgroup { get; set; }

        [StringLength(600)]
        public string description_item { get; set; }

        [StringLength(600)]
        public string description_brand { get; set; }

        [StringLength(255)]
        public string image_thumbnail { get; set; }

        [StringLength(255)]
        public string image_medium { get; set; }

        [StringLength(255)]
        public string image_large { get; set; }

        [StringLength(255)]
        public string image_brand_band { get; set; }

        [StringLength(255)]
        public string image_brand_label { get; set; }

        [StringLength(255)]
        public string video_brand { get; set; }

        public int? is_free_shipping { get; set; }

        public int? is_new { get; set; }

        public int? is_on_sale { get; set; }

        [StringLength(50)]
        public string keyword { get; set; }

        public decimal? price_retail { get; set; }

        public decimal? price_sale { get; set; }

        public decimal? price_srp { get; set; }

        public decimal? price_sort { get; set; }

        [StringLength(20)]
        public string sku { get; set; }

        public decimal? sort_default { get; set; }

        [StringLength(255)]
        public string url_detail { get; set; }

        [StringLength(255)]
        public string url_detail2 { get; set; }

        [StringLength(255)]
        public string brandlink { get; set; }

        [StringLength(255)]
        public string brandgrouplink { get; set; }

        public int? is_discontinued { get; set; }

        [StringLength(20)]
        public string category_id { get; set; }

        public decimal? margin { get; set; }

        public int? is_kit { get; set; }

        public int? offer { get; set; }

        public int? is_rev { get; set; }

        public int? sortorder1 { get; set; }

        public int? avail { get; set; }

        [StringLength(10)]
        public string brand_code { get; set; }

        [StringLength(5)]
        public string bgcode { get; set; }

        public int? is_tiered { get; set; }

        public int? humidor_trays { get; set; }

        public int? famous_exclusives { get; set; }

        public int? humidifier_included { get; set; }

        [StringLength(50)]
        public string wrapper_color { get; set; }

        public decimal? avg_rating { get; set; }

        public int? brand_rating { get; set; }

        [StringLength(50)]
        public string package_type { get; set; }

        public decimal? humidor_length { get; set; }

        public decimal? humidor_capacity { get; set; }

        public decimal? humidor_width { get; set; }

        [StringLength(50)]
        public string shape { get; set; }

        [StringLength(50)]
        public string country_of_origin { get; set; }

        [StringLength(50)]
        public string humidor_color { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? subihdnum { get; set; }

        [StringLength(50)]
        public string strength { get; set; }

        public decimal? length { get; set; }

        public int? ring_gauge { get; set; }

        [StringLength(50)]
        public string group_id { get; set; }

        [StringLength(50)]
        public string humidor_material { get; set; }

        [StringLength(50)]
        public string humidor_size { get; set; }

        [StringLength(50)]
        public string tube { get; set; }

        public decimal? vote_count { get; set; }

        [StringLength(50)]
        public string flavor { get; set; }

        public decimal? humidor_depth { get; set; }

        [StringLength(50)]
        public string cigar_type { get; set; }

        public int? boxpress { get; set; }

        public decimal? quantity { get; set; }

        public int? hygrometer_included { get; set; }

        public int? brandgroup_id { get; set; }

        public int? brand_code_id { get; set; }

        public int? category_id_id { get; set; }

        public int? cigar_type_id { get; set; }

        public int? country_of_origin_id { get; set; }

        public int? flavor_id { get; set; }

        public int? humidor_color_id { get; set; }

        public int? humidor_material_id { get; set; }

        public int? humidor_size_id { get; set; }

        public int? package_type_id { get; set; }

        public int? shape_id { get; set; }

        public int? strength_id { get; set; }

        public int? wrapper_color_id { get; set; }

        public int? brand_id { get; set; }

        [StringLength(255)]
        public string sampler_brand_ids { get; set; }

        [StringLength(255)]
        public string sampler_group_ids { get; set; }

        [Column(TypeName = "text")]
        public string sampler_ids_qtys { get; set; }

        [StringLength(100)]
        public string itemdes2 { get; set; }

        [StringLength(15)]
        public string sizestr { get; set; }

        [StringLength(25)]
        public string wrapper_origin { get; set; }

        [StringLength(25)]
        public string wrapperleaf_type { get; set; }

        public int? wrapper_origin_id { get; set; }

        public int? wrapperleaf_type_id { get; set; }

        [StringLength(1)]
        public string paok { get; set; }

        [StringLength(1)]
        public string sflg { get; set; }

        [StringLength(100)]
        public string normbrand { get; set; }

        [StringLength(100)]
        public string normbrandgroup { get; set; }

        [StringLength(100)]
        public string normname { get; set; }

        public DateTime? fsaled { get; set; }

        public DateTime? tsaled { get; set; }

        [StringLength(4)]
        public string pref { get; set; }

        public int? realavail { get; set; }

        [StringLength(50)]
        public string acc_color { get; set; }

        public int? acc_color_id { get; set; }

        public int? show_wrapper { get; set; }

        public int? mostly_acc { get; set; }

        public int? percent_off { get; set; }

        [StringLength(50)]
        public string device_type { get; set; }

        public int? device_type_id { get; set; }

        public int? nic_strength { get; set; }

        public int? prod_life { get; set; }

        [StringLength(50)]
        public string ec_flavor { get; set; }

        public int? ec_flavor_id { get; set; }

        [StringLength(50)]
        public string ec_tip_color { get; set; }

        public int? ec_tip_color_id { get; set; }

        [StringLength(50)]
        public string ec_color { get; set; }

        public int? ec_color_id { get; set; }

        public int? ec_size { get; set; }

        public int? pkg_qty { get; set; }

        public long? sort_sale_margin { get; set; }

        public int? is_monster { get; set; }

        public decimal? price_monster { get; set; }

        [StringLength(255)]
        public string brand_review_link { get; set; }

        [StringLength(255)]
        public string item_review_link { get; set; }

        [StringLength(128)]
        public string package_string { get; set; }

        [StringLength(512)]
        public string offer_info { get; set; }

        [StringLength(256)]
        public string preorder_message { get; set; }

        [Column(TypeName = "date")]
        public DateTime? preorder_date { get; set; }

        public int? has_free_offer { get; set; }
    }
}
