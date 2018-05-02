namespace FamousHumidors.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Items : DbContext
    {
        public Items()
            : base("name=Items")
        {
        }

        public virtual DbSet<Item> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.name_cleaned)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.name_display)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.brand)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.brandgroup)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.description_item)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.description_brand)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.image_thumbnail)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.image_medium)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.image_large)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.image_brand_band)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.image_brand_label)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.video_brand)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.keyword)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.sku)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.url_detail)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.url_detail2)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.brandlink)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.brandgrouplink)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.category_id)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.brand_code)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.bgcode)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.wrapper_color)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.package_type)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.humidor_length)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.humidor_capacity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Item>()
                .Property(e => e.humidor_width)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.shape)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.country_of_origin)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.humidor_color)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.subihdnum)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Item>()
                .Property(e => e.strength)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.length)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.group_id)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.humidor_material)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.humidor_size)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.tube)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.vote_count)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Item>()
                .Property(e => e.flavor)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.humidor_depth)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Item>()
                .Property(e => e.cigar_type)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Item>()
                .Property(e => e.sampler_brand_ids)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.sampler_group_ids)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.sampler_ids_qtys)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.itemdes2)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.sizestr)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.wrapper_origin)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.wrapperleaf_type)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.paok)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.sflg)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.normbrand)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.normbrandgroup)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.normname)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.pref)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.acc_color)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.device_type)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ec_flavor)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ec_tip_color)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ec_color)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.brand_review_link)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.item_review_link)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.package_string)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.offer_info)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.preorder_message)
                .IsUnicode(false);
        }
    }
}
