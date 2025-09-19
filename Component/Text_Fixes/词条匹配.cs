namespace Stationeers_Fixes_Package
{
  public static partial class 扩展方法
  {
    public static string 词条匹配(this string 源)
    {
      string 结果 = null;

      switch (源)
      {
        //菜单界面
        case "LoadingScreenNewWorldMenu": 结果 = "初始化菜单"; break;
        //加载界面
        case "LoadingScreenInitializing": 结果 = "初始化游戏"; break;
        case "LoadingScreenInitializingChunks": 结果 = "初始化游戏物品"; break;
        case "LoadingScreenGeneratingRecipes": 结果 = "加载游戏物品"; break;
        case "LoadingScreenInitializingDevices": 结果 = "初始化函数"; break;
        //成就系统
        case "Achievements": 结果 = "成就系统"; break;
        case "Calm weather": 结果 = "平静的天气"; break;

        //钻机
        case "Flatten": 结果 = "找平模式"; break;
        case "Default": 结果 = "标准模式"; break;

        //喷气背包
        case "Stabilizer": 结果 = "自动悬停"; break;
        case "Stabilizer {0}": 结果 = "自动悬停 {0}"; break;    // 可能被编译器优化成格式化字符串
        case "Detonate": 结果 = "引爆炸弹"; break;

        //游戏词条
        case "Weather damage": 结果 = "天气伤害"; break;
        case "Lander": 结果 = "着陆器"; break;
        case "Creative mode": 结果 = "创造模式"; break;
        case "Metabolism": 结果 = "新陈代谢"; break;
        case "Nutrition": 结果 = "新陈代谢之营养"; break;
        case "Hydration": 结果 = "新陈代谢之水分"; break;
        case "Breathing": 结果 = "新陈代谢之呼吸"; break;
        case "Robot Battery": 结果 = "机器人电池消耗"; break;
        case "Mood reduction": 结果 = "新陈代谢之情绪"; break;
        case "Hygiene reduction": 结果 = "新陈代谢之卫生"; break;
        case "Food decay": 结果 = "食物腐烂"; break;
        case "Jetpack consumption": 结果 = "飞行消耗"; break;
        case "Mining": 结果 = "矿物开采"; break;
        case "Lung damage": 结果 = "肺部伤害"; break;
        case "Offline metabolism": 结果 = "离线新陈代谢"; break;

        case "disabled": 结果 = "禁用"; break;
        case "enabled": 结果 = "启用"; break;

        case "Growth Efficiency": 结果 = "生长效率"; break;
        case "Breathing Efficiency": 结果 = "呼吸效率"; break;
        case "Temperature Efficiency": 结果 = "温度效率"; break;
        case "Pressure Efficiency": 结果 = "压力效率"; break;
        case "Light Efficiency": 结果 = "光合效率"; break;
        case "Hydration Efficiency": 结果 = "水合效率"; break;

        case "Min Ideal Temperature": 结果 = "最小理想温度"; break;
        case "Max Ideal Temperature": 结果 = "最大理想温度"; break;
        case "Current Temperature": 结果 = "当前大气温度"; break;

        case "Min Ideal Pressure": 结果 = "最小理想压力"; break;
        case "Max Ideal Pressure": 结果 = "最大理想压力"; break;
        case "Current Pressure": 结果 = "当前大气压力"; break;

        case "Light Intensity": 结果 = "光照强度"; break;
        case "Illumination Stress": 结果 = "作息紊乱率(调节光暗时长恢复)"; break;

        case "Light Deficiency": 结果 = "光照生长需求"; break;
        case "Darkness Deficiency": 结果 = "黑暗睡眠需求"; break;

        case "Creative Spawn Menu": 结果 = "物品生成窗口"; break;
        case "Search": 结果 = "搜索"; break;

        case "Helmet": 结果 = "头盔"; break;
        case "Suit": 结果 = "太空服"; break;
        case "Back": 结果 = "背部"; break;
        case "Uniform": 结果 = "制服"; break;
        case "Glasses": 结果 = "眼镜"; break;
        case "Belt": 结果 = "腰带"; break;
        case "Access Card": 结果 = "门禁卡"; break;
        case "Credit Card": 结果 = "银行卡"; break;
        case "Tool": 结果 = "工具"; break;
        case "Sensor Processing Unit": 结果 = "传感器处理单元"; break;
        case "Battery": 结果 = "电池"; break;
        case "Cartridge": 结果 = "记忆卡"; break;
        case "Programmable Chip": 结果 = "可编程芯片"; break;
        case "Ore": 结果 = "矿石"; break;


        case "Growth Speed Multiplier": { 结果 = "生长速度"; break; }
        case "Dark Per Day": { 结果 = "黑暗需求"; break; }
        case "Light Per Day": { 结果 = "光照需求"; break; }
        case "Drought Tolerance": { 结果 = "干旱抗性"; break; }
        case "Water Usage": { 结果 = "用水需求"; break; }
        case "Low Pressure Resistance": { 结果 = "低压耐受"; break; }
        case "Low Temperature Resistance": { 结果 = "低温耐受"; break; }
        case "Undesired Gas Tolerance": { 结果 = "毒素抗性"; break; }
        case "Gas Production": { 结果 = "气体呼吸"; break; }
        case "High Pressure Resistance": { 结果 = "高压耐受"; break; }
        case "High Temperature Resistance": { 结果 = "高温耐受"; break; }
        case "Suffocation Tolerance": { 结果 = "窒息抗性"; break; }
        case "Low Pressure Tolerance": { 结果 = "低压抗性"; break; }
        case "Low Temperature Tolerance": { 结果 = "低温抗性"; break; }
        case "High Pressure Tolerance": { 结果 = "高压抗性"; break; }
        case "High Temperature Tolerance": { 结果 = "高温抗性"; break; }
        case "Undesired Gas Resistance": { 结果 = "毒素耐受"; break; }
        case "Light Tolerance": { 结果 = "光照抗性"; break; }
        case "Darkness Tolerance": { 结果 = "黑暗抗性"; break; }

        case "More Ore Less": 结果 = "MoreOreLess-<size=88%>矿石</size>"; break;
        case "Asteroid Assayers": 结果 = "AsteroidAssayers-<size=88%>矿石</size>"; break;
        case "Cosmic Crush": 结果 = "CosmicCrush-<size=88%>矿石</size>"; break;
        case "Galactic Gravels": 结果 = "GalacticGravels-<size=88%>矿石</size>"; break;
        case "Nebula Nuggets": 结果 = "NebulaNuggets-<size=88%>矿石</size>"; break;
        case "Orbit Ore Oasis": 结果 = "OrbitOreOasis-<size=88%>矿石</size>"; break;
        case "Stellar Stone Supply": 结果 = "StellarStoneSupply-<size=88%>矿石</size>"; break;
        case "Interstellar Excavators": 结果 = "InterstellarExcavators-<size=88%>矿石</size>"; break;
        case "Void Vein Vendors": 结果 = "VoidVeinVendors-<size=88%>矿石</size>"; break;
        case "Planetary Pebbles": 结果 = "PlanetaryPebbles-<size=88%>矿石</size>"; break;

        case "All Alloys": 结果 = "AllAlloys-<size=88%>合金</size>"; break;
        case "Metal Mavens": 结果 = "MetalMavens-<size=88%>合金</size>"; break;
        case "AstroAlloy Emporium": 结果 = "AstroAlloyEmporium-<size=88%>合金</size>"; break;
        case "Cosmic Forge": 结果 = "CosmicForge-<size=88%>合金</size>"; break;
        case "Galactic Metallurgy": 结果 = "GalacticMetallurgy-<size=88%>合金</size>"; break;
        case "OrbitOre Outfitters": 结果 = "OrbitOreOutfitters-<size=88%>合金</size>"; break;
        case "Stellar Smelter": 结果 = "StellarSmelter-<size=88%>合金</size>"; break;
        case "Interstellar Ingots": 结果 = "InterstellarIngots-<size=88%>合金</size>"; break;
        case "Nebula Nucleus": 结果 = "NebulaNucleus-<size=88%>合金</size>"; break;
        case "Space Alloy Specialists": 结果 = "SpaceAlloySpecialists-<size=88%>合金</size>"; break;
        case "Star Smelter": 结果 = "StarSmelter-<size=88%>合金</size>"; break;

        case "Starlight Suppers": 结果 = "StarlightSuppers-<size=88%>食品</size>"; break;
        case "Galactic Groceries": 结果 = "GalacticGroceries-<size=88%>食品</size>"; break;
        case "Orbiting Organics": 结果 = "OrbitingOrganics-<size=88%>食品</size>"; break;
        case "Cosmic Cuisine": 结果 = "CosmicCuisine-<size=88%>食品</size>"; break;
        case "Asteroid Eats": 结果 = "AsteroidEats-<size=88%>食品</size>"; break;
        case "Nebula Nibbles": 结果 = "NebulaNibbles-<size=88%>食品</size>"; break;
        case "Stellar Snacks": 结果 = "StellarSnacks-<size=88%>食品</size>"; break;
        case "Interstellar Ingredients": 结果 = "InterstellarIngredients-<size=88%>食品</size>"; break;
        case "Space Spices": 结果 = "SpaceSpices-<size=88%>食品</size>"; break;
        case "Void Vegetables": 结果 = "VoidVegetables-<size=88%>食品</size>"; break;
        case "Planetary Produce": 结果 = "PlanetaryProduce-<size=88%>食品</size>"; break;

        case "Green Futures": 结果 = "GreenFutures-<size=88%>水培</size>"; break;
        case "AstroAgronomics": 结果 = "AstroAgronomics-<size=88%>水培</size>"; break;
        case "Stellar Sprouts": 结果 = "StellarSprouts-<size=88%>水培</size>"; break;
        case "HydroHarvest Haven": 结果 = "HydroHarvestHaven-<size=88%>水培</size>"; break;
        case "Orbiting Orchards": 结果 = "OrbitingOrchards-<size=88%>水培</size>"; break;
        case "Galactic Growers": 结果 = "GalacticGrowers-<size=88%>水培</size>"; break;
        case "CosmoCrop Connect": 结果 = "CosmoCropConnect-<size=88%>水培</size>"; break;
        case "Space Sprout Suppliers": 结果 = "SpaceSproutSuppliers-<size=88%>水培</size>"; break;
        case "Nebula Nurturers": 结果 = "NebulaNurturers-<size=88%>水培</size>"; break;
        case "Star Seedlings": 结果 = "StarSeedlings-<size=88%>水培</size>"; break;
        case "EcoSphere Essentials": 结果 = "EcoSphereEssentials-<size=88%>水培</size>"; break;
        case "Interstellar Irrigation": 结果 = "InterstellarIrrigation-<size=88%>水培</size>"; break;

        case "GasForLess": 结果 = "GasForLess-<size=88%>气体</size>"; break;
        case "AstroAether": 结果 = "AstroAether-<size=88%>气体</size>"; break;
        case "Cosmic Clouds": 结果 = "CosmicClouds-<size=88%>气体</size>"; break;
        case "Nebula Nectars": 结果 = "NebulaNectars-<size=88%>气体</size>|<size=88%>液体</size>"; break;
        case "Orbiting Oxygens": 结果 = "OrbitingOxygens-<size=88%>气体</size>"; break;
        case "Galactic Gases": 结果 = "GalacticGases-<size=88%>气体</size>"; break;
        case "Stellar Steam": 结果 = "StellarSteam-<size=88%>气体</size>"; break;
        case "Interstellar Inhalants": 结果 = "InterstellarInhalants-<size=88%>气体</size>"; break;
        case "Void Vapors": 结果 = "VoidVapors-<size=88%>气体</size>"; break;
        case "Space Gas Station": 结果 = "SpaceGasStation-<size=88%>气体</size>"; break;

        case "Build INC": 结果 = "Build INC-建材"; break;

        case "Payless Liquids": 结果 = "PaylessLiquids-<size=88%>液体</size>"; break;
        case "Frosty Barrels": 结果 = "FrostyBarrels-<size=88%>液体</size>"; break;
        case "Cosmic Concoctions": 结果 = "CosmicConcoctions-<size=88%>液体</size>"; break;
        case "Galactic Gush": 结果 = "GalacticGush-<size=88%>液体</size>"; break;
        case "Orbital Oceans": 结果 = "OrbitalOceans-<size=88%>液体</size>"; break;
        case "Stellar Streams": 结果 = "StellarStreams-<size=88%>液体</size>"; break;
        case "Interstellar Icicles": 结果 = "InterstellarIcicles-<size=88%>液体</size>"; break;
        case "Void Vessels": 结果 = "VoidVessels-<size=88%>液体</size>"; break;
        case "Space Springs": 结果 = "SpaceSprings-<size=88%>液体</size>"; break;
        case "Star Sippers": 结果 = "StarSippers-<size=88%>液体</size>"; break;

        case "Cosmic Tools &amp; More": 结果 = "CosmicTools&amp;More-<size=88%>成品</size>"; break;
        case "Galactic Gearworks": 结果 = "GalacticGearworks-<size=88%>成品</size>"; break;
        case "Stellar Supplies": 结果 = "StellarSupplies-<size=88%>成品</size>"; break;
        case "OrbitOps Hardware": 结果 = "OrbitOpsHardware-<size=88%>成品</size>"; break;
        case "Interstellar Implements": 结果 = "InterstellarImplements-<size=88%>成品</size>"; break;
        case "Void Ventures": 结果 = "VoidVentures-<size=88%>成品</size>"; break;
        case "Asteroid Artisans": 结果 = "AsteroidArtisans-<size=88%>成品</size>"; break;
        case "Space Spanners": 结果 = "SpaceSpanners-<size=88%>成品</size>"; break;
        case "Meteor Mechanics": 结果 = "MeteorMechanics-<size=88%>成品</size>|<size=88%>家电</size>"; break;

        case "AstroMart": 结果 = "AstroMart-<size=88%>耗材</size>"; break;
        case "Cosmo's Convenience": 结果 = "Cosmo'sConvenience-<size=88%>耗材</size>"; break;
        case "StarStop": 结果 = "StarStop-<size=88%>耗材</size>"; break;
        case "Nebula Necessities": 结果 = "NebulaNecessities-<size=88%>耗材</size>"; break;
        case "Interstellar Essentials": 结果 = "InterstellarEssentials-<size=88%>耗材</size>"; break;
        case "Void Vending": 结果 = "VoidVending-<size=88%>耗材</size>"; break;
        case "Meteor Munchies": 结果 = "MeteorMunchies-<size=88%>耗材</size>"; break;

        case "Galactic Gadgets": 结果 = "GalacticGadgets-<size=88%>家电</size>"; break;
        case "Orbitron Appliances": 结果 = "OrbitronAppliances-<size=88%>家电</size>"; break;
        case "Stellar Systems Store": 结果 = "StellarSystemsStore-<size=88%>家电</size>"; break;
        case "Space Savvy Solutions": 结果 = "SpaceSavvySolutions-<size=88%>家电</size>"; break;
        case "Interstellar Innovations": 结果 = "InterstellarInnovations-<size=88%>家电</size>"; break;
        case "Void Visions": 结果 = "VoidVisions-<size=88%>家电</size>"; break;
        case "Asteroid Appliances": 结果 = "AsteroidAppliances-<size=88%>家电</size>"; break;
      }

      return 结果 ?? 源;
    }
  }
}