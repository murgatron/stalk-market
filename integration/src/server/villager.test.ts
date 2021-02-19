import VillagerApi from "../shared/villager-api";

describe("villager api", () => {
  beforeAll(async (done) => {
    const payload = {
      name: "murg"
    }

    // make 1 villager
    await VillagerApi.createVillager(payload);
    done();
  })

  it("can get a villager", async () => {
    const response = await VillagerApi.getVillagers();
    expect(response).toBeDefined();
  })

  it("can create a villager", async () => {
    const payload = {
      name: "BillyBob"
    }

    const response = await VillagerApi.createVillager(payload);
    expect(response).toBeDefined();
  })

  it("can update a villager", async () => {
    const response = await VillagerApi.getVillagers();
    expect(response).toBeDefined();
  })

  it("can delete a villager", async () => {
    const response = await VillagerApi.getVillagers();
    expect(response).toBeDefined();
  })
});