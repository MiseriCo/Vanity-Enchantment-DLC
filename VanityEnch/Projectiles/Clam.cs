using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace VanityEnch.Projectiles
{
	public class Clam : ModProjectile
	{
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mermaid Enchantment Clam");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Projectile.damage = 10;
            Projectile.penetrate = 5;
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.friendly = true;
            //Projectile.aiStyle = -1;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.ai[0] += 1;
            if (Projectile.ai[0] == 60) 
            {
                Projectile.Kill();
            }
        }
        
        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.penetrate -= 1;
            if (Projectile.penetrate <= 0) {
                Projectile.Kill();
            }
        }
        */
    }
}