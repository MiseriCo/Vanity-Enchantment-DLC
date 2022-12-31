using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using VanityEnch.Items;
using VanityEnch.Projectiles;
using Terraria.GameInput;

namespace VanityEnch
{
	public partial class VanityModPlayer : ModPlayer
	{
        public Item MermaidEnchant;
        public Item TaxEnchant;
        public Item RuneEnchant;
        public int Coins = 4;
        public int TaxCooldown = 0;
        
        public override void ResetEffects()
        {
            MermaidEnchant = null;
            TaxEnchant = null;
            RuneEnchant = null;
        }

        public override void PostUpdate()
        {
            if (Coins < 4) 
            {
                TaxCooldown++;
                if (TaxCooldown == 180)
                {
                    Coins++;
                    TaxCooldown = 0;
                }
            }

            base.PostUpdate();
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (VanityEnchMod.TaxCoinBind.JustPressed && TaxEnchant != null && Coins > 0)
            {
                Vector2 coinvel;
                coinvel.X = 0;
                coinvel.Y = -8.0f;
                Projectile.NewProjectile(Player.GetSource_Accessory(TaxEnchant), Main.player[Main.myPlayer].Center, coinvel, ModContent.ProjectileType<UKCoin>(), 0, 0.0f, Main.myPlayer);
                Coins--;
            }
            /*if (VanityEnchMod.TaxPunchBind.JustPressed && TaxEnchant != null)
            {
                Vector2 forward;
                forward.X = 5;
                forward.Y = 0;
                Vector2 spawn = Main.player[Main.myPlayer].position;
                spawn.Y += 20;
                Projectile.NewProjectile(Player.GetSource_Accessory(TaxEnchant), spawn, forward, ModContent.ProjectileType<UKPunch>(), 20, 2.0f, Main.myPlayer);
            }*/
            base.ProcessTriggers(triggersSet);
        }
        public override void OnHitAnything(float x, float y, Entity victim)
        {
            Vector2 coords, vel;
            coords.X = x;
            coords.Y = y;
            vel.X = 0;
            vel.Y = 0;
            if (MermaidEnchant != null && (Player.wet || Player.HasBuff(BuffID.Wet)))
            {
                Projectile.NewProjectile(Player.GetSource_Accessory(MermaidEnchant), coords, vel, ModContent.ProjectileType<Clam>(), 20, 0f, Main.myPlayer);
            }
        }
    }
}