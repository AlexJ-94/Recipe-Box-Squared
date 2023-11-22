import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { pantryItems: [], loading: true };
  }

  componentDidMount() {
    this.populatePantryData();
  }

  static renderPantryTable(pantryItems) {
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Expiration Date</th>
          </tr>
        </thead>
        <tbody>
          {pantryItems.map(pantryItem =>
            <tr key={pantryItem.id}>
              <td>{pantryItem.id}</td>
              <td>{new Date(pantryItem.name.toDateString())}</td>
              <td>{pantryItem.expiration_date}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderPantryTable(this.state.pantryItems);

    return (
      <div>
        <h1 id="tableLabel">Pantry Items</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populatePantryData() {
    const response = await fetch('pantry');
    const data = await response.json();
    this.setState({ pantryItems: data, loading: false });
  }
}
