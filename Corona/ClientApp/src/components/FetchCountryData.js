import React, { Component } from 'react';

export class FetchCountryData extends Component {
    static displayName = FetchCountryData.name;

    constructor(props) {
        super(props);
        this.state = { countries: [], loading: true };
    }

    componentDidMount() {
        this.populateCountryData();
    }

    static renderCountryTable(countries) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Confirmed</th>
                    </tr>
                </thead>
                <tbody>
                    {countries.turkey.map(forecast =>
                        <tr key={forecast.date}>
                            <td>{forecast.date}</td>
                            <td>{forecast.confirmed}</td>
                        </tr>
                    )}
                </tbody>
            </table>
            
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchCountryData.renderCountryTable(this.state.countries);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateCountryData() {
        const response = await fetch('corona');
        const data = await response.json();
        this.setState({ countries: data, loading: false });
    }
}
