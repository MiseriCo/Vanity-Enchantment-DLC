using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VanityEnch;
using Terraria.GameContent.Creative;

namespace VanityEnch.Items
{
	public class TaxEnch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tax Collector Enchantment");
			Tooltip.SetDefault("When the kill is ultra!");
		}

        public override void SetDefaults()
        {
			Item.width = 20;
			Item.height = 20;
			Item.accessory = true;
            base.SetDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            VanityModPlayer modPlayer = player.GetModPlayer<VanityModPlayer>();
            modPlayer.TaxEnchant = Item;

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TaxCollectorHat)
                .AddIngredient(ItemID.TaxCollectorPants)
                .AddIngredient(ItemID.TaxCollectorSuit)
                .AddTile(TileID.WorkBenches)
                .Register();
            base.AddRecipes();
        }
    }
}