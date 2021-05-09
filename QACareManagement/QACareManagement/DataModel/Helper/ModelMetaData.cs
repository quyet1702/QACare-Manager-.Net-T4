//
// Điều chỉnh display name cho tất cả các page có dùng tên cột dữ liệu tương ứng
//

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


// Mặc dù khác thư mục nhưng để trùng trùng với các DataModel phát sinh từ code
// comment cái .Help để nó trùng namespace 
namespace QACareManagement.DataModel/*.Helper*/
{

    //public class ModelMetaData { }

    [ModelMetadataType(typeof(CustomerMetaData))]
    public partial class Customer { }
    public partial class CustomerMetaData
    {
        [Display(Name = "Họ Tên")]
        public string FullName { get; set; }
        [Display(Name = "Số Điện Thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Loại K.H")]
        public string Role { get; set; }


        [NotMapped]
        [Display(Name = "Ngày Tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CreateDate { get; set; }

        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public string CreateTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

    }


    // Sản Phẩm
    [ModelMetadataType(typeof(ProductMetaData))]
    public partial class Product { }
    public partial class ProductMetaData
    {
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
    }


    // C.Trình tích điểm/đổi  quà
    [ModelMetadataType(typeof(PromotionGiftMetaData))]
    public partial class PromotionGift { }
    public partial class PromotionGiftMetaData
    {
        [Display(Name = "Tên Chương Trình")]
        public string Title { get; set; }

        [Display(Name = "Mô Tả")]
        public string Description { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        public string StartDateRunning { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string EndRunRunning { get; set; }

        [Display(Name = "Tổng Điểm Phát Hành")]
        public string TotalPointRelease { get; set; }

        [Display(Name = "Tổng Số Người Được Đăng Ký")]
        public int NumOfTotalRegisterAllow { get; set; }


        [Display(Name = "Tổng Điểm Mỗi Đăng Ký Sẽ Đạt")]
        public int TotalPointEachRegister { get; set; }

        [Display(Name = "Số Điểm Mỗi Lần Quét QR Được")]
        public int NumOfPointEachScan { get; set; }

        [Display(Name = "Hàng Ngày Cho Phép Quét Tối Đa")]
        public int NumOfAllowScanDaily { get; set; }

        [Display(Name = "Giờ Bắt Đầu Cho Phép Quét Hàng Ngày (Nếu có)")]
        public TimeSpan StarTimeAllowScanDaily { get; set; }

        [Display(Name = "Giờ Kết Thúc Cho Phép Quét Hàng Ngày (Nếu Có)")]
        public TimeSpan EndTimeAllowScanDaily { get; set; }

        [Display(Name = "Loại Chương trình")]
        public short Type { get; set; }

        [Display(Name = "Đối tác vận hành")]
        public int DealerCustomer { get; set; }

        [Display(Name = "Địa điểm")]
        public int RegisterLocationCustomerAddressId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeSpan CreateTime { get; set; }

        [Column(TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }
    }


    [ModelMetadataType(typeof(CustomerAddressMetaData))]
    public partial class CustomerAddress { }
    public partial class CustomerAddressMetaData
    {
        [Display(Name = "Số Nhà và Tên Đường")]

        public string StreetAddress { get; set; }
        [Display(Name = "Phường/Xã")]
        public string Ward { get; set; }
        [Display(Name = "Quận/Huyện")]
        public string Province { get; set; }
        [Display(Name = "Tỉnh/Thành Phố")]
        public string City { get; set; }

    }


    [ModelMetadataType(typeof(PromotionGiftProductMetaData))]
    public partial class PromotionGiftProduct { }
    public partial class PromotionGiftProductMetaData
    {
        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Giá")]
        public int Price { get; set; }
    }


    [ModelMetadataType(typeof(PromotionGiftImageUploadMetaData))]
    public partial class PromotionGiftImageUpload
    {
        [NotMapped]
        [Display(Name = "Hình Upload")]
        public IFormFile ImageFile { get; set; }
    }
    public partial class PromotionGiftImageUploadMetaData { }



}
