using Microsoft.EntityFrameworkCore;
using receipt_app.models;

namespace receipt_app;

public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
{
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Receipt> Receipts => Set<Receipt>();
    public DbSet<ReceiptItem> ReceiptItems => Set<ReceiptItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<ReceiptItem>()
            .HasKey(ri => new { ri.ReceiptId, ri.ItemId }); // Composite key

        modelBuilder.Entity<ReceiptItem>()
            .HasOne(ri => ri.Receipt)
            .WithMany(r => r.ReceiptItems)
            .HasForeignKey(ri => ri.ReceiptId);

        modelBuilder.Entity<ReceiptItem>()
            .HasOne(ri => ri.Item)
            .WithMany(i => i.ReceiptItems)
            .HasForeignKey(ri => ri.ItemId);
    }
}
