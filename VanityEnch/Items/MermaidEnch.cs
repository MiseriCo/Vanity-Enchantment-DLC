using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VanityEnch;
using Terraria.GameContent.Creative;

namespace VanityEnch.Items
{
	public class MermaidEnch : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mermaid Enchantment");
			Tooltip.SetDefault("This is a basic modded sword.");
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
            modPlayer.MermaidEnchant = Item;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MermaidAdornment)
                .AddIngredient(ItemID.MermaidTail)
                .AddTile(TileID.WorkBenches)
                .Register();
            base.AddRecipes();
        }
    }
}