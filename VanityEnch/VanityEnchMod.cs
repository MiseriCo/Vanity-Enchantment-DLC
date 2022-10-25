using Terraria.ModLoader;

namespace VanityEnch
{
	public class VanityEnchMod : Mod
	{
		internal static ModKeybind TaxCoinBind;

        public override void Load()
        {
            TaxCoinBind = KeybindLoader.RegisterKeybind(this, "Tax Enchantment Coin Toss", Microsoft.Xna.Framework.Input.Keys.Z);
        }

        public override void Unload()
        {
            TaxCoinBind = null;
            base.Unload();
        }


    }
}