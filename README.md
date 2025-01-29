# Queen Anne Curiosity Shop

## Overview
The **Queen Anne Curiosity Shop** is an upscale home furnishing store located in a well-to-do urban neighborhood. The store specializes in selling both antiques and current-production household items that complement or are useful with antiques. Customers include individuals, bed-and-breakfast owners, and interior designers working with individuals and small businesses.

## Business Model
- **Antique Items**: Unique pieces purchased from individuals and wholesalers. Some antiques, like dining room chairs, are sold as sets (which are never broken).
- **New Items**: Regularly stocked household items purchased from distributors. These items can be reordered when out of stock and are available in various sizes and colors.

## Software Overview
The Queen Anne Curiosity Shop application is developed using **Windows Presentation Foundation (WPF)** programmed in **C#**, with an **SQL database** for backend storage. The software enhances store operations by managing inventory, transactions, procurement, shipments, and vendor relationships efficiently.

## Key Features
### Inventory Management
- **Antique Items**: Each antique is a unique entry in the inventory and cannot be reordered.
- **New Items**: Items are categorized by type, size, and color, with availability for restocking.
- **Shopping Cart System**: Users can add or remove items from inventory with adjustable quantities.

### Transaction Management
- View transaction history with **pagination and statistics**.
- **Add new transactions** with invoice numbers, transaction types, and customer details.
- **Check-Out System**: Single-page checkout with dropdowns for customer and transaction types.

### Customer and Employee Records
- Maintain a database of **customers and employees**.
- Store and manage **addresses, contact details, and transaction history**.

### Shipments and Procurement
- **Shipment Tracking**: Record and monitor all shipments, including **departure and arrival dates**.
- **Procurement Management**: Assign vendors to specific items and track item quality, purchase orders, and shipments.
- **Vendor Management**: Maintain a detailed list of all vendors, including company and contact details.

### Business Rules
- Each address can have multiple persons.
- A single transaction can involve multiple persons and multiple items.
- **Unique Antique Items** can only be sold once, while **new items** can be reordered.
- Vendors can be classified as individuals or companies and supply multiple different items.
- A **shipment can contain multiple items**, each with an insured value for protection.
- A receiving clerk verifies shipment conditions and contents.

## Future Enhancements
- **Online Inventory System**: To track stock levels and streamline reordering processes.
- **E-Commerce Platform**: Enabling online purchases and delivery options.
- **Customer Loyalty Program**: Offering incentives for repeat customers and designers.

## How to Contribute
If you would like to contribute to this project, please follow these steps:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature-branch`)
3. Commit your changes (`git commit -m 'Add new feature'`)
4. Push to the branch (`git push origin feature-branch`)
5. Open a Pull Request

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact Information
For more details, please contact me at deguzman.adriankent@gmail.com.

