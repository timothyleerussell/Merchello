﻿// <auto-generated/> - StyleCop hack to not enforce commentation errors in this file.
namespace Merchello.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Merchello.Core.Models;


    /// <summary>
    /// Extension methods for <see cref="ILineItemContainer"/>.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Gets the tax line items.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The collection of tax line items.
        /// </returns>
        public static IEnumerable<ILineItem> TaxLineItems(this ILineItemContainer container)
        {
            return container.Items.Where(x => x.LineItemType == LineItemType.Tax);
        }

        /// <summary>
        /// Gets the product line items.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The collection of product line items.
        /// </returns>
        public static IEnumerable<ILineItem> ProductLineItems(this ILineItemContainer container)
        {
            return container.Items.Where(x => x.LineItemType == LineItemType.Product);
        }

        /// <summary>
        /// Gets the shipping line items.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The collection of shipping line item.
        /// </returns>
        public static IEnumerable<ILineItem> ShippingLineItems(this ILineItemContainer container)
        {
            return container.Items.Where(x => x.LineItemType == LineItemType.Shipping);
        }

        /// <summary>
        /// Gets the discount line items.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The collection of discount line items.
        /// </returns>
        public static IEnumerable<ILineItem> DiscountLineItems(this ILineItemContainer container)
        {
            return container.Items.Where(x => x.LineItemType == LineItemType.Discount);
        }

        /// <summary>
        /// Gets the custom line items.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The collection of customer line items.
        /// </returns>
        public static IEnumerable<ILineItem> CustomLineItems(this ILineItemContainer container)
        {
            return container.Items.Where(x => x.LineItemType == LineItemType.Custom);
        }

        /// <summary>
        /// Adds a <see cref="IProductVariant"/> line item to the collection
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="productVariant">
        /// The product Variant.
        /// </param>
        /// <param name="quantity">
        /// The quantity.
        /// </param>
        public static void AddItem(this ILineItemContainer container, IProductVariant productVariant, int quantity)
        {
            var extendedData = new ExtendedDataCollection();

            container.AddItem(productVariant, quantity, extendedData);
        }


        /// <summary>
        /// Adds a <see cref="IProductVariant"/> line item to the collection
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="productVariant">
        /// The product Variant.
        /// </param>
        /// <param name="quantity">
        /// The quantity.
        /// </param>
        /// <param name="extendedData">
        /// The extended Data.
        /// </param>
        public static void AddItem(this ILineItemContainer container, IProductVariant productVariant, int quantity, ExtendedDataCollection extendedData)
        {
            extendedData.AddProductVariantValues(productVariant);
            container.AddItem(LineItemType.Product, productVariant.Name, productVariant.Sku, quantity, productVariant.Price, extendedData);
        }


        /// <summary>
        /// Adds a line item to the collection
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="lineItemType">
        /// The line Item Type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="sku">
        /// The sku.
        /// </param>
        /// <param name="quantity">
        /// The quantity.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        public static void AddItem(this ILineItemContainer container, LineItemType lineItemType, string name, string sku, int quantity, decimal amount)
        {
            container.AddItem(lineItemType, name, sku, quantity, amount, new ExtendedDataCollection());
        }

        /// <summary>
        /// Adds a line item to the collection
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="lineItemType">
        /// The line Item Type.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="sku">
        /// The sku.
        /// </param>
        /// <param name="quantity">
        /// The quantity.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <param name="extendedData">
        /// The extended Data.
        /// </param>
        public static void AddItem(this ILineItemContainer container, LineItemType lineItemType, string name, string sku, int quantity, decimal amount, ExtendedDataCollection extendedData)
        {
            var lineItem = new ItemCacheLineItem(lineItemType, name, sku, quantity, amount, extendedData)
            {
                ContainerKey = container.Key
            };

            container.AddItem(lineItem);
        }

        /// <summary>
        /// Adds a line item to the collection
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="lineItem">
        /// The line Item.
        /// </param>
        public static void AddItem(this ILineItemContainer container, ILineItem lineItem)
        {
            lineItem.ContainerKey = container.Key;
            container.Items.Add(lineItem);
        }
    }
}
