export default class {
  constructor(axiosClient) {
    this.axiosClient = axiosClient;
  }

  async get(resource, options) {
    return await this.axiosClient.get(resource, options);
  }

  async post(resource, options) {
    return await this.axiosClient.post(resource, options.payload, options);
  }

  async put(resource, options) {
    return await this.axiosClient.put(resource, options.payload, options);
  }

  async delete(resource, options) {
    return await this.axiosClient.delete(resource, options);
  }
}
