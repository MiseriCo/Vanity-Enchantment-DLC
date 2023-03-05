using Terraria.ModLoader;

namespace VanityEnch
{
	public class VanityEnchMod : Mod
	{
		internal static ModKeybind TaxCoinBind;
        internal static ModKeybind TaxPunchBind;

        public override void Load()
        {
            TaxCoinBind = KeybindLoader.RegisterKeybind(this, "Tax Enchantment Coin Toss", Microsoft.Xna.Framework.Input.Keys.Z);
            TaxPunchBind = KeybindLoader.RegisterKeybind(this, "Tax Enchantment Cool Punch", Microsoft.Xna.Framework.Input.Keys.F);
        }

        public override void Unload()
        {
            TaxCoinBind = null;
            TaxPunchBind = null;
            base.Unload();
        }


    }
}