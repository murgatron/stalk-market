import { Hemisphere } from "./Hemisphere";
import { Region } from "./Region";

export default interface IIsland {
  id: string;
  name: string;
  salesTax?: number;
  ownerId: string;
  hemisphere: Hemisphere;
  region: Region;
} 